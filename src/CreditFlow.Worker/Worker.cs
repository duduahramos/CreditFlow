using System.Text.Json;
using System.Text.Json.Serialization;
using CreditFlow.Core.Application;
using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.Messaging.Services;
using CreditFlow.Infrastructure.Respositories.Interfaces;

namespace CreditFlow.Workers;

public class Worker : BackgroundService
{
    private readonly SQSManager _sqs;
    private readonly string _sqsUrl;
    private readonly CreditRequestValidator _creditRequestValidator;

    public Worker(SQSManager sqsManager, IConfiguration configuration, CreditRequestValidator creditRequestValidator)
    {
        _sqs = sqsManager;
        _sqsUrl = configuration["SQS:CreditRequest"];
        _creditRequestValidator = creditRequestValidator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var messages = await _sqs.GetMessageAsync(_sqsUrl);

            while (messages.Any())
            {
                foreach (var message in messages)
                {
                    CreditRequest creditRequest = JsonSerializer.Deserialize<CreditRequest>(message.Body);

                    var creditValidationResult = await _creditRequestValidator.ValidateAsync(creditRequest, stoppingToken);
                    
                    creditRequest.RequestStatus = creditValidationResult.RequestStatus; 
                }
            }
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}
