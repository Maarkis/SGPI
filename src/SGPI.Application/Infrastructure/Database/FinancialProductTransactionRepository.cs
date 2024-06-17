using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database.Contracts;

namespace SGPI.Application.Infrastructure.Database;

public interface IFinancialProductTransactionRepository : IAddRepository<FinancialProductTransaction>, ISaveRepository;

public class FinancialProductTransactionRepository(IAppDatabaseContext context) : IFinancialProductTransactionRepository
{
    public async Task<Guid> AddAsync(FinancialProductTransaction entity, CancellationToken cancellationToken = default)
    {
        await context.FinancialProductTransactions.AddAsync(entity, cancellationToken);
        return entity.Id;
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}