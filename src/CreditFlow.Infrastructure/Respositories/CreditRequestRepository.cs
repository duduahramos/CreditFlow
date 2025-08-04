using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Respositories.Interfaces;

namespace CreditFlow.Infrastructure.Respositories;

public class CreditRequestRepository : ICreditRequestRepository
{
    private readonly CreditDBContext _dbContext;

    public CreditRequestRepository(CreditDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task SaveAsync(CreditRequest request, CancellationToken cancellationToken = default)
    {
        _dbContext.CreditRequests.Add(request);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}