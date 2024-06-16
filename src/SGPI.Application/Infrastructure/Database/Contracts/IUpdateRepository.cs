using SGPI.Domain.Entities.Abstract;

namespace SGPI.Application.Infrastructure.Database.Contracts;

public interface IUpdateRepository<in T> where T : Entity
{
    public void UpdateAsync(T entity);
}