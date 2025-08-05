namespace CreditFlow.API.Auth;

public class JWTOptions
{
    public string SecretKey { get; set; }
    public int AccessTokenExpirationMinutes { get; set; }
    public int RefreshTokenExpirationDays { get; set; }
}