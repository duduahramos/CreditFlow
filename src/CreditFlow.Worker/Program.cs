using CreditFlow.Core.Application;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Messaging.Services;
using CreditFlow.Infrastructure.Respositories;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using CreditFlow.Workers;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<SQSManager>();
builder.Services.AddSingleton<CreditRequestValidator>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
