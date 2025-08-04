using System.Text.Json;
using CreditFlow.Core.Application;
using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.Messaging.Services;
using CreditFlow.Infrastructure.Respositories.Interfaces;

namespace CreditFlow.Workers;

public class Worker : BackgroundService
{
    private readonly SQSManager _sqsManager;
    private readonly string _sqsUrl;
    private readonly CreditRequestValidator _creditRequestValidator;
    private readonly ICreditRequestRepository _creditRequestRepository;

    public Worker(
        SQSManager sqsManagerManager,
        IConfiguration configuration,
        CreditRequestValidator creditRequestValidator,
        ICreditRequestRepository creditRequestRepository
    )
    {
        _sqsManager = sqsManagerManager;
        _sqsUrl = configuration["SQS:CreditRequest"];
        _creditRequestValidator = creditRequestValidator;
        _creditRequestRepository = creditRequestRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var messages = await _sqsManager.GetMessageAsync(_sqsUrl);

            while (messages.Any())
            {
                foreach (var message in messages)
                {
                    CreditRequest creditRequest = JsonSerializer.Deserialize<CreditRequest>(message.Body);

                    var creditValidationResult = await _creditRequestValidator.ValidateAsync(creditRequest, stoppingToken);
                    
                    creditRequest.RequestStatus = creditValidationResult.RequestStatus;
                    creditRequest.UpdatedAt = DateTime.UtcNow;
                    creditRequest.EndedAt = DateTime.UtcNow;

                    await _creditRequestRepository.UpdateASync(creditRequest);

                    await _sqsManager.DeleteMessageAsync(_sqsUrl, message.ReceiptHandle);
                }
            }
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}
