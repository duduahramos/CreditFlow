using System.ComponentModel.DataAnnotations;
using CreditFlow.Core.Domain.Enums;

namespace CreditFlow.Core.Domain.Entities;

public class CreditRequest
{
    public Guid Id { get; init; } = Guid.NewGuid();
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid ClientId { get; init; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Cpf { get;  set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public decimal MonthlyIncome { get;  set; }
    [Required]
    public decimal RequestAmount { get;  set; }
    [Required]
    public int CreditScore { get;  set; }
    [Required]
    public bool HasDebtHistory { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    [Required]
    public DateTime? UpdatedAt { get; set; }
    [Required]
    public DateTime? EndedAt { get; set; }
    public CreditRequestStatus RequestStatus { get; set; } = CreditRequestStatus.Pending;
    
    public int Age => DateTime.UtcNow.Year - BirthDate.Year;
}