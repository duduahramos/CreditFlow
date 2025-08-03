using CreditFlow.Core.Domain.Entities;
using CreditFlow.Core.Domain.Interfaces;
using CreditFlow.Core.Domain.Results;

namespace CreditFlow.Core.Domain.Rules;

public class ScoreValidationRule : ICreditRule
{
    public string Name { get { return "ScoreValidation"; } }
    private const int MinimumScore = 650;

    public Task<RuleValidationResult> ValidateAsync(CreditRequest request, CancellationToken cancellationToken = default)
    {
        if (request.CreditScore < MinimumScore)
        {
            return Task.FromResult(RuleValidationResult.Fail(Name, $"Score must be at leat {MinimumScore}."));
        }

        return Task.FromResult(RuleValidationResult.Success(Name));
    }
}