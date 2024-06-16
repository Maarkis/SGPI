using Microsoft.EntityFrameworkCore;
using SGPI.Application.Domain.Entities;
using SGPI.Application.Infrastructure.Database.Contracts;

namespace SGPI.Application.Infrastructure.Database;

public interface IFinancialProductTransactionRepository : IAddRepository<FinancialProductTransaction>, ISaveRepository
{
    public Task<IEnumerable<FinancialProductTransaction>> GetByClientIdAndTransactionTypeAsync(int clientId,
        TransactionType? transactionType, CancellationToken cancellationToken = default);
}

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

    public async Task<IEnumerable<FinancialProductTransaction>> GetByClientIdAndTransactionTypeAsync(int clientId,
        TransactionType? transactionType,
        CancellationToken cancellationToken = default)
    {
        var query = context
            .FinancialProductTransactions
            .Where(x => x.ClientId == clientId);

        if (transactionType is not null)
            query = query.Where(x => x.TransactionType == transactionType);

        return await query
            .ToListAsync(cancellationToken);
    }
}