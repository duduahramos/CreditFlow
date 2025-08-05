using CreditFlow.Core.Common.Extensions;
using CreditFlow.Core.Domain.Entities;
using CreditFlow.Core.Domain.Interfaces;
using CreditFlow.Core.Domain.Results;

namespace CreditFlow.Core.Domain.Rules;

public class CpfBlacklistRule : ICreditRule
{
    public string Name { get { return "CpfBlacklist"; } }

    private static readonly HashSet<string> Blacklisted = new()
    {
        "00000000000",
        "11111111111",
        "22222222222",
        "33333333333",
        "44444444444",
        "55555555555",
        "66666666666",
        "77777777777",
        "88888888888",
        "99999999999",
    };

    public Task<RuleValidationResult> ValidateAsync(CreditRequest request, CancellationToken cancellationToken = default)
    {
        if (Blacklisted.Contains(request.Cpf.OnlyDigits()))
        {
            return Task.FromResult(RuleValidationResult.Fail(Name, $"CPF {request.Cpf.ToString()} is blacklisted"));
        }

        return Task.FromResult(RuleValidationResult.Success(Name));
    }
}