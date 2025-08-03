using CreditFlow.Core.Domain.Entities;
using CreditFlow.Core.Domain.Interfaces;
using CreditFlow.Core.Domain.Results;

namespace CreditFlow.Core.Domain.Rules;

public class PaymentHistoryRule : ICreditRule
{
    public string Name { get { return "PaymentHistory"; } }
    public Task<RuleValidationResult> ValidateAsync(CreditRequest request, CancellationToken cancellationToken = default)
    {
        if (request.HasDebtHistory)
        {
            return Task.FromResult(RuleValidationResult.Fail(Name, "Applicant has a negative payment history."));
        }

        return Task.FromResult(RuleValidationResult.Success(Name));
    }
}