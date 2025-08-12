using System.ComponentModel.DataAnnotations;

namespace CreditFlow.Core.Domain.Entities;

public class Login
{
    [Key]
    public string Username { get; init; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}