using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task UpdateASync(CreditRequest request, CancellationToken cancellationToken = default)
    {
        _dbContext.CreditRequests.Update(request);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<CreditRequest> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.CreditRequests.FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }
}