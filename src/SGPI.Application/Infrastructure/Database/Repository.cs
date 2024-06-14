using SGPI.Domain.Entities;
using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Infrastructure.Database;


// TODO: Move to interfaces.
public interface ISaveRepository
{
    public Task SaveAsync(CancellationToken cancellationToken = default);
}

public interface IAddRepository<in T> where T : Entity
{
    public Task<Guid> AddAsync(T entity, CancellationToken cancellationToken = default);
}

public interface IGetByIdRepository<T> where T : Entity
{
    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}

public interface IGetAllRepository<T> where T : Entity
{
    public Task<FinancialProduct[]> GetAllAsync(CancellationToken cancellationToken = default);
}

public interface IUpdateRepository<in T> where T : Entity
{
    public void UpdateAsync(T entity);
}

public interface IDeleteRepository
{
    public Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}

public interface IFinancialProductRepository : 
    IAddRepository<FinancialProduct>,
    IGetByIdRepository<FinancialProduct>,
    IGetAllRepository<FinancialProduct>,
    IUpdateRepository<FinancialProduct>,
    IDeleteRepository,
    ISaveRepository
{
}


