namespace CreditFlow.Core.Common.Extensions;

public static class StringExtensions
{
    public static string OnlyDigits(this string input)
    {
        return new string(input.Where(char.IsDigit).ToArray());
    }

    public static bool IsNullOrEmpty(this string input)
    {
        return string.IsNullOrEmpty(input);
    }

    public static bool IsNullOrWhiteSpace(this string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}