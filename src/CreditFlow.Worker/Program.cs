using CreditFlow.Core.Application;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Messaging.Services;
using CreditFlow.Infrastructure.Respositories;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

// Connection string do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Postgres");

// 1. Adiciona o DbContext com tempo de vida Scoped
builder.Services.AddDbContext<CreditDBContext>(options =>
    options.UseNpgsql(connectionString));

// 2. Registra o repositório como Scoped (porque depende do DbContext)
builder.Services.AddScoped<ICreditRequestRepository, CreditRequestRepository>();

// 3. Registra SQSManager e Validator como Singleton (ok)
builder.Services.AddSingleton<SQSManager>();
builder.Services.AddSingleton<CreditRequestValidator>();

// 4. Adiciona o Worker como HostedService
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();