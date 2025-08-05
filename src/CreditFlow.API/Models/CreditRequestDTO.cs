using System.Text.Json.Serialization;
using CreditFlow.Core.Domain.Enums;

namespace CreditFlow.API.Models;

public class CreditRequestDTO
{
    [JsonIgnore]
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Cpf { get;  init; }
    public int Age { get;  init; }
    public decimal MonthlyIncome { get;  init; }
    public decimal RequestAmount { get;  init; }
    public int CreditScore { get;  init; }
    public bool HasDebtHistory { get; init; }
    [JsonIgnore]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    [JsonIgnore]
    public DateTime? UpdatedAt { get; init; }
    [JsonIgnore]
    public DateTime? EndedAt { get; init; }
    public string RequestStatus { get; init; }
}