using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Infrastructure.Database.Contracts;

public interface IAddRepository<in T> where T : Entity
{
    public Task<Guid> AddAsync(T entity, CancellationToken cancellationToken = default);
}