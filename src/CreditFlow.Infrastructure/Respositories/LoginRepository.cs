using CreditFlow.Core.Domain.Entities;
using CreditFlow.Infrastructure.Data;
using CreditFlow.Infrastructure.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditFlow.Infrastructure.Respositories;

public class LoginRepository : ILoginRepository
{
    private readonly CreditDBContext _dbContext; 
    
    public LoginRepository(CreditDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task UpdateASync(Login login, CancellationToken cancellationToken = default)
    {
        var loginDB = await _dbContext.Logins.FirstOrDefaultAsync(x => x.Username == login.Username);

        if (loginDB == null)
        {
            await _dbContext.Logins.AddAsync(login);
        }
        else
        {
            _dbContext.Logins.Update(login);
        }

        await _dbContext.SaveChangesAsync();
    }
}