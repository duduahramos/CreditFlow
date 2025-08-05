namespace CreditFlow.Core.Common.Extensions;

public static class AuthExtensions
{
    public static bool IsValidUsername(this string username)
    {
        if (username.IsNullOrWhiteSpace() || username.IsNullOrEmpty() || username.Length < 8)
        {
            return false;
        }

        return true;
    }

    public static bool IsValidPassword(this string password)
    {
        if (password.IsNullOrWhiteSpace() || password.IsNullOrEmpty() || password.Length < 8)
        {
            return false;
        }

        return true;
    }
}