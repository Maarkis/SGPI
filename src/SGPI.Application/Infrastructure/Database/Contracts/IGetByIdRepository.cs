using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Infrastructure.Database.Contracts;

public interface IGetByIdRepository<T> where T : Entity
{
    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}