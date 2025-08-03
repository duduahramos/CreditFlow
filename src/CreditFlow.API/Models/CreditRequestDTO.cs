namespace CreditFlow.API.Models;

public class CreditRequestDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Cpf { get;  init; }
    public int Age { get;  init; }
    public decimal MonthlyIncome { get;  init; }
    public decimal RequestAmount { get;  init; }
    public int CreditScore { get;  init; }
    public bool HasDebtHistory { get; init; }
}