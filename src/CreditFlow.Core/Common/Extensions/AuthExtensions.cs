namespace CreditFlow.Core.Common.Extensions;

public static class AuthExtensions
{
    public static bool IsValidUsername(this string username)
    {
        if (username.IsNullOrWhiteSpace() || username.IsNullOrEmpty())
        {
            return false;
        }

        return true;
    }

    public static bool IsValidPassword(this string password)
    {
        if (password.IsNullOrWhiteSpace() || password.IsNullOrEmpty())
        {
            return false;
        }

        return true;
    }
}