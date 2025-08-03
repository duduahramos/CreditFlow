namespace CreditFlow.Core.Domain.Results;

public class RuleValidationResult
{
    public bool IsValid { get; set; }
    public string RuleName { get; set; }
    public string? ErrorMessage { get; set; }

    public static RuleValidationResult Success(string ruleName)
    {
        return new RuleValidationResult 
        {
            IsValid = true,
            RuleName = ruleName
        };
    }

    public static RuleValidationResult Fail(string ruleName, string message)
    {
        return new RuleValidationResult 
        {
            IsValid = false,
            RuleName = ruleName,
            ErrorMessage = message
        };
    }
}