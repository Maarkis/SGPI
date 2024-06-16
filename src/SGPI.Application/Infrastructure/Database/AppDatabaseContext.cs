using Microsoft.EntityFrameworkCore;
using SGPI.Application.Domain.Entities;

namespace SGPI.Application.Infrastructure.Database;

public interface IAppDatabaseContext
{
    public DbSet<FinancialProduct> FinancialProducts { get; }
    public DbSet<FinancialProductTransaction> FinancialProductTransactions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : DbContext(options), IAppDatabaseContext
{
    public DbSet<FinancialProduct> FinancialProducts => Set<FinancialProduct>();
    public DbSet<FinancialProductTransaction> FinancialProductTransactions => Set<FinancialProductTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDatabaseContext).Assembly);
    }
}