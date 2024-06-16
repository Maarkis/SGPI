using Microsoft.EntityFrameworkCore;
using SGPI.Application.Domain.Entities;

namespace SGPI.Application.Infrastructure.Database;

public interface IAppDatabaseContext
{
    public DbSet<FinancialProduct> FinancialProducts { get; }
}

public class AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : DbContext(options), IAppDatabaseContext
{
    public DbSet<FinancialProduct> FinancialProducts => Set<FinancialProduct>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDatabaseContext).Assembly);
    }
}