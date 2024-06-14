using SGPI.Domain.Entities;

namespace SGPI.Domain.Interfaces;


public interface IAddRepository<in T> 
{
    public void AddAsync(T entity);
}

public class Repository<T> : IAddRepository<T>
{
    public Repository(IApplicationDbContext context)
    {
        
    }
    public void Add(T entity)
    {
        
    }
    public void AddAsync(T entity)
    {
        
    }
}