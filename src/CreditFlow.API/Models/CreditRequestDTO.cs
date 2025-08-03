using CreditFlow.Core.Domain.Enums;

namespace CreditFlow.API.Models;

public class CreditRequestDTO
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Cpf { get;  init; }
    public int Age { get;  init; }
    public decimal MonthlyIncome { get;  init; }
    public decimal RequestAmount { get;  init; }
    public int CreditScore { get;  init; }
    public bool HasDebtHistory { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; init; }
    public DateTime? EndedAt { get; init; }
    public CreditRequestStatus RequestStatus { get; init; } = CreditRequestStatus.Pending;
}