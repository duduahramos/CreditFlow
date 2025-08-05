namespace CreditFlow.Core.Common.Extensions;

public static class GuidExtensions
{
    public static bool IsNullOrEmpty(this Guid input)
    {
        return (input == Guid.Empty);
    }
}