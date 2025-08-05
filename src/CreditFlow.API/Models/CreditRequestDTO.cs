using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CreditFlow.Core.Domain.Enums;

namespace CreditFlow.API.Models;

public class CreditRequestDTO
{
    [JsonIgnore]
    public Guid Id { get; set; }
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
    [JsonIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [JsonIgnore]
    public DateTime? UpdatedAt { get; set; }
    [JsonIgnore]
    public DateTime? EndedAt { get; set; }
    [JsonIgnore]
    public string RequestStatus { get; set; }
}