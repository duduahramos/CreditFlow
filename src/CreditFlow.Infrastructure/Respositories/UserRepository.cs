using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditFlow.Infrastructure.Respositories;

public class UserRepository : IUserRepository
{
    private readonly CreditDBContext _dbContext;

    public UserRepository(CreditDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task SaveAsync(User user, CancellationToken cancellationToken = default)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateASync(User user, CancellationToken cancellationToken = default)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }

    public async Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);

        return result;
    }
}