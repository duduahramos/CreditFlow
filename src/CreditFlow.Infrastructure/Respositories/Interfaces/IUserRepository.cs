using CreditFlow.Core.Domain.Entities;

namespace CreditFlow.Infrastructure.Respositories.Interfaces;

public interface IUserRepository
{
    Task SaveAsync(User user, CancellationToken cancellationToken = default);
    Task UpdateASync(User user, CancellationToken cancellationToken = default);
    Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
}