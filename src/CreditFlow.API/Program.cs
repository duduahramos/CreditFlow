using CreditFlow.Core.Application;
using CreditFlow.Core.Domain.Interfaces;
using CreditFlow.Core.Domain.Rules;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Messaging.Services;
using CreditFlow.Infrastructure.Respositories;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICreditRule, AgeValidationRule>();
builder.Services.AddScoped<ICreditRule, ScoreValidationRule>();
builder.Services.AddScoped<ICreditRule, CpfBlacklistRule>();
builder.Services.AddScoped<ICreditRule, IncomeToLoanRatioRule>();
builder.Services.AddScoped<ICreditRule, PaymentHistoryRule>();

builder.Services.AddScoped<CreditRequestValidator>();

builder.Services.AddDbContext<CreditDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddScoped<ICreditRequestRepository, CreditRequestRepository>();

builder.Services.AddScoped<SQSManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
