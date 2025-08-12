using CreditFlow.Core.Domain.Enums;
using Newtonsoft.Json;

namespace CreditFlow.Core.Domain.Entities;

public class UserResponseDTO
{
    [JsonIgnore]
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public AdminLevel AdminLevel { get; set; }
    public DateTime CreatedAt { get; init; } 
    
}