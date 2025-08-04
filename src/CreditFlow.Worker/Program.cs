using CreditFlow.Infrastructure.Messaging.Services;
using CreditFlow.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<SQSManager>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
