using CreditFlow.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditFlow.Infrastructure.Data;

public class CreditDBContext : DbContext
{
    public DbSet<CreditRequest> CreditRequests => Set<CreditRequest>();

    public CreditDBContext(DbContextOptions<CreditDBContext> options) : base(options)
    {
        
    }
}