using System.Text.Json;
using CreditFlow.Core.Application;
using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.AWS;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Respositories.Interfaces;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly SQSManager _sqsManager;
    private readonly string _sqsUrl;
    private readonly CreditRequestValidator _creditRequestValidator;

    public Worker(
        IServiceProvider serviceProvider,
        SQSManager sqsManager,
        IConfiguration configuration,
        CreditRequestValidator creditRequestValidator)
    {
        _serviceProvider = serviceProvider;
        _sqsManager = sqsManager;
        _sqsUrl = configuration["SQS:CreditRequest"];
        _creditRequestValidator = creditRequestValidator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var messages = await _sqsManager.GetMessageAsync(_sqsUrl);

            foreach (var message in messages)
            {
                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<CreditDBContext>();
                var repository = scope.ServiceProvider.GetRequiredService<ICreditRequestRepository>();

                var creditRequest = JsonSerializer.Deserialize<CreditRequest>(message.Body);
                var validationResult = await _creditRequestValidator.ValidateAsync(creditRequest, stoppingToken);

                creditRequest.RequestStatus = validationResult.RequestStatus;
                creditRequest.UpdatedAt = DateTime.UtcNow;
                creditRequest.EndedAt = DateTime.UtcNow;

                await repository.UpdateASync(creditRequest);
                await _sqsManager.DeleteMessageAsync(_sqsUrl, message.ReceiptHandle);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}