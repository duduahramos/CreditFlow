using CreditFlow.Core.Domain.Entities;
using CreditFlow.Core.Domain.Results;

namespace CreditFlow.Core.Domain.Interfaces;

public interface ICreditRule
{
    string Name { get; }
    
    Task<RuleValidationResult> ValidateAsync(CreditRequest request, CancellationToken cancellationToken = default);
}