using System.Diagnostics;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace CreditFlow.Infrastructure.Messaging.Services;

public class SQSManager
{
    private readonly IAmazonSQS _sqs;

    public SQSManager()
    {
        _sqs = new AmazonSQSClient();
    }
    
    public async Task SendMessageAsync(string? qUrl, string messageBody)
    {
        SendMessageResponse responseSendMsg = await _sqs.SendMessageAsync(qUrl, messageBody);
        Console.WriteLine($"Message added to queue\n  {qUrl}");
        Console.WriteLine($"HttpStatusCode: {responseSendMsg.HttpStatusCode}");
    }

    public async Task<List<Message>> GetMessageAsync(string qUrl)
    {
        ReceiveMessageResponse responseReceiveMsg = await _sqs.ReceiveMessageAsync(qUrl);

        return responseReceiveMsg.Messages;
    }

    public async Task DeleteMessageAsync(string qUrl, string receiptHandle)
    {
        await _sqs.DeleteMessageAsync(qUrl, receiptHandle);
    }
}