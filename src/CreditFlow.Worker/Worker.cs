using CreditFlow.Infrastructure.Messaging.Services;

namespace CreditFlow.Workers;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly SQSManager _sqs;
    private readonly string _sqsUrl;

    public Worker(ILogger<Worker> logger, SQSManager sqsManager, IConfiguration configuration)
    {
        _logger = logger;
        _sqs = sqsManager;
        _sqsUrl = configuration["SQS:CreditRequest"];
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var messages = await _sqs.GetMessageAsync(_sqsUrl);

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
