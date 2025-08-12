using CreditFlow.Core.Domain.Entities;

namespace CreditFlow.Infrastructure.Respositories.Interfaces;

public interface ILoginRepository
{
    Task UpdateASync(Login login, CancellationToken cancellationToken = default);
}