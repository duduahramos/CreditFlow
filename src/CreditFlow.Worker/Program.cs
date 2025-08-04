using CreditFlow.Core.Application;
using CreditFlow.Infrastructure.Messaging.Services;
using CreditFlow.Infrastructure.Respositories;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using CreditFlow.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<SQSManager>();
builder.Services.AddSingleton<CreditRequestValidator>();
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<ICreditRequestRepository, CreditRequestRepository>();

var host = builder.Build();
host.Run();
