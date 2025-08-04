using CreditFlow.Core.Domain.Entities;
using CreditFlow.Core.Domain.Interfaces;
using CreditFlow.Core.Domain.Results;

namespace CreditFlow.Core.Domain.Rules;

public class AgeValidationRule : ICreditRule
{
    public string Name { get { return "AgeValidation"; } }
    private const int MinimumAge = 18;
    public Task<RuleValidationResult> ValidateAsync(CreditRequest request, CancellationToken cancellationToken = default)
    {
        if (request.Age < MinimumAge)
        {
            return Task.FromResult(RuleValidationResult.Fail(Name, $"Applicant must be at least {MinimumAge} years old."));
        }

        return Task.FromResult(RuleValidationResult.Success(Name));
    }
}