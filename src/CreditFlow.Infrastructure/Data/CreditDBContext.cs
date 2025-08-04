using CreditFlow.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditFlow.Infrastructure.Data;

public class CreditDBContext : DbContext
{
    public DbSet<CreditRequest> CreditRequests => Set<CreditRequest>();

    public CreditDBContext() { }
    public CreditDBContext(DbContextOptions<CreditDBContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=creditflow.cofwegkgsqsi.us-east-1.rds.amazonaws.com;Port=5432;Database=CreditRequests;Username=admin_user;Password=adminPWD"); // fallback
        }
    }
}