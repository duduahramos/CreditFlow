using CreditFlow.Core.Domain.Entities;
using CreditFlow.Core.Domain.Interfaces;
using CreditFlow.Core.Domain.Results;

namespace CreditFlow.Core.Domain.Rules;

public class IncomeToLoanRatioRule : ICreditRule
{
    public string Name { get { return "IncomeToLoanRatio"; } }
    private const decimal MinimumRatio = 2.0m;

    public Task<RuleValidationResult> ValidateAsync(CreditRequest request, CancellationToken cancellationToken = default)
    {
        if (request.RequestAmount == 0)
        {
            return Task.FromResult(RuleValidationResult.Fail(Name, "Requested amount cannot be zero."));
        }
        
        var loanRatio = request.MonthlyIncome / request.RequestAmount;

        if (loanRatio >= MinimumRatio)
        {
            return Task.FromResult(RuleValidationResult.Success(Name));
        }

        return Task.FromResult(
            RuleValidationResult.Fail(
                Name,
                $"Monthly income must be at least {MinimumRatio}x greater than the requested amount.")
            );
    }
}