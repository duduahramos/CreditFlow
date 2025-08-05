using Newtonsoft.Json;

namespace CreditFlow.Core.Domain.Entities;

public class UserDTO
{
    [JsonIgnore]
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password{ get; set; }
    public DateTime CreatedAt { get; init; } 
    
}