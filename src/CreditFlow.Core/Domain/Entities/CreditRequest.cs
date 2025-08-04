using CreditFlow.Core.Domain.Enums;

namespace CreditFlow.Core.Domain.Entities;

public class CreditRequest
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Cpf { get;  init; }
    public int Age { get;  init; }
    public decimal MonthlyIncome { get;  init; }
    public decimal RequestAmount { get;  init; }
    public int CreditScore { get;  init; }
    public bool HasDebtHistory { get; init; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public CreditRequestStatus RequestStatus { get; set; } = CreditRequestStatus.Pending;
}