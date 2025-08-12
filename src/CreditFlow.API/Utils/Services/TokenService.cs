using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Amazon.SecretsManager;
using CreditFlow.API.DTOs;
using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.AWS;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CreditFlow.API.Utils.Services;

public class TokenService
{
    private readonly SecretManager _secretsManager;
    
    public TokenService(SecretManager secretManager)
    {
        _secretsManager = secretManager;
    }
    
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
    
    public async Task<string> GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName)
        };
        
        var secretKey = await _secretsManager.GetSecret("creditflow-jwt-key");
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var jwtToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: credentials
        );
        
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        
        return token;
    }
}