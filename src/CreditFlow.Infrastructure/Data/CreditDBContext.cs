using CreditFlow.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditFlow.Infrastructure.Data;

public class CreditDBContext : DbContext
{
    public DbSet<CreditRequest> CreditRequests => Set<CreditRequest>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Login> Logins => Set<Login>();

    public CreditDBContext() { }
    public CreditDBContext(DbContextOptions<CreditDBContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=creditflow.cofwegkgsqsi.us-east-1.rds.amazonaws.com;Port=5432;Database=creditflow_db;Username=adminUSER;Password=adminPASSWORD"); // fallback
        }
    }
}