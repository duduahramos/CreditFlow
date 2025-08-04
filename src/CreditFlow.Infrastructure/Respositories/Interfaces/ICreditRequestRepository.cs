using CreditFlow.Core.Domain.Entities;

namespace CreditFlow.Infrastructure.Respositories.Interfaces;

public interface ICreditRequestRepository
{
    Task SaveAsync(CreditRequest request, CancellationToken cancellationToken = default);
    Task UpdateASync(CreditRequest request, CancellationToken cancellationToken = default);
}