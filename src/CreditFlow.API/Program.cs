using System.Text;
using CreditFlow.API.Auth;
using CreditFlow.Core.Application;
using CreditFlow.Core.Domain.Interfaces;
using CreditFlow.Core.Domain.Rules;
using CreditFlow.Infrastructure.AWS;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Respositories;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddScoped<ICreditRule, AgeValidationRule>();
// builder.Services.AddScoped<ICreditRule, ScoreValidationRule>();
// builder.Services.AddScoped<ICreditRule, CpfBlacklistRule>();
// builder.Services.AddScoped<ICreditRule, IncomeToLoanRatioRule>();
// builder.Services.AddScoped<ICreditRule, PaymentHistoryRule>();

builder.Services.AddScoped<CreditRequestValidator>();

builder.Services.AddDbContext<CreditDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddScoped<ICreditRequestRepository, CreditRequestRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<SQSManager>();
// builder.Services.AddScoped<SecretManager>();

var jwtOptions = new JWTOptions
{
    SecretKey = await SecretManager.GetSecret(builder.Configuration.GetSection("JWT:SecretKey").Value),
    AccessTokenExpirationMinutes = int.Parse(builder.Configuration.GetSection("JWT:AccessTokenExpirationMinutes").Value),
    RefreshTokenExpirationDays = int.Parse(builder.Configuration.GetSection("JWT:RefreshTokenExpirationDays").Value)
};

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var secretKey = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);
    });

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
