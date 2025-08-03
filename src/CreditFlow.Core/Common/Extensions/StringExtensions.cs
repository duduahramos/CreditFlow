namespace CreditFlow.Core.Common.Extensions;

public static class StringExtensions
{
    public static string OnlyDigits(this string input)
    {
        return new string(input.Where(char.IsDigit).ToArray());
    }
}