using Microsoft.EntityFrameworkCore;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database;

namespace SGPI.Application.Infrastructure;

public class FinancialProductRepository(AppDatabaseContext context) : IFinancialProductRepository
{
    private readonly DbSet<FinancialProduct> _dbSet = context.FinancialProducts;

    public async Task<Guid> AddAsync(FinancialProduct entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity.Id;
    }

    public Task<FinancialProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<FinancialProduct>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public void UpdateAsync(FinancialProduct entity)
    {
        _dbSet.Update(entity);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _dbSet.Where(entity => entity.Id == id).ExecuteDeleteAsync(cancellationToken);
    }
}