namespace CreditFlow.Core.Domain.Entities;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow; 
    
}