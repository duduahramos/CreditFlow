using System.Security.Cryptography;
using System.Text;

namespace CreditFlow.Core.Common.Helpers;

public static class AuthHelper
{
    public static string GenerateSalt(int size = 32)
    {
        var saltBytes = new byte[size];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }

    public static string HashPassword(string password, string salt, int iterations = 100_000)
    {
        var saltBytes = Convert.FromBase64String(salt);
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        using var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(32); // 256 bits

        return Convert.ToBase64String(hash);
    }

    public static bool VerifyPassword(string requestPassword, string userSalt, string userHash)
    {
        var hash = HashPassword(requestPassword, userSalt);

        return hash == userHash;
    }
}