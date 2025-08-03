namespace CreditFlow.Core.Domain.Entities;

public class CreditRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Cpf { get;  init; }
    public int Age { get;  init; }
    public decimal MonthlyIncome { get;  init; }
    public decimal RequestAmount { get;  init; }
    public int CreditScore { get;  init; }
    public bool HasDebtHistory { get; init; }
}