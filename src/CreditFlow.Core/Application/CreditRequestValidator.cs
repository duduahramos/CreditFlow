using CreditFlow.Core.Domain.Entities;
using CreditFlow.Core.Domain.Interfaces;
using CreditFlow.Core.Domain.Results;

namespace CreditFlow.Core.Application;

public class CreditRequestValidator
{
    private readonly IEnumerable<ICreditRule> _rules;

    public CreditRequestValidator(IEnumerable<ICreditRule> rules)
    {
        _rules = rules;
    }

    public async Task<CreditValidationResult> ValidateAsync(CreditRequest request, CancellationToken cancellationToken = default)
    {
        var tasks = _rules.Select(rule => rule.ValidateAsync(request, cancellationToken));
        
        var ruleResult = await Task.WhenAll(tasks);
        
        return CreditValidationResult.FromRules(request.Id, ruleResult);
    }
}