using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Infrastructure.Database.Contracts;

public interface IGetAllRepository<T> where T : Entity
{
    public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
}