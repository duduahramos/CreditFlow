using Newtonsoft.Json;

namespace CreditFlow.API.DTOs;

public class LoginDTO
{
    public string Username { get; init; }
    public string Token { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; }
}