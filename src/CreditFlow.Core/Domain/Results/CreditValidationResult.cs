using CreditFlow.Core.Domain.Enums;

namespace CreditFlow.Core.Domain.Results;

public class CreditValidationResult
{
    public Guid RequestId { get; set; }
    public CreditRequestStatus RequestStatus { get; set; }
    public List<RuleValidationResult> RuleResults { get; set; } = new();
    
    public bool IsApproved()
    {
        return RequestStatus == CreditRequestStatus.Approved;
    }

    public static CreditValidationResult FromRules(Guid requestId, IEnumerable<RuleValidationResult> results)
    {
        var allRulesPassed = results.All(r => r.IsValid);

        return new CreditValidationResult
        {
            RequestId = requestId,
            RuleResults = results.ToList(),
            RequestStatus = allRulesPassed ? CreditRequestStatus.Approved : CreditRequestStatus.Rejected
        };
    }
}