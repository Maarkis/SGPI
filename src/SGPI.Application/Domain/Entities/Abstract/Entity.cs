namespace SGPI.Domain.Entities.Abstract;

public abstract class Entity
{
    /// <summary>
    ///     Creates an instance of the Entity class based on the provided value.
    /// </summary>
    protected Entity()
    {
    }

    /// <summary>
    ///     Creates an instance of the Entity class based on the provided value.
    /// </summary>
    /// <param name="id"> The id of the entity.</param>
    protected Entity(Guid id)
    {
        Id = id;
    }

    /// <summary>
    ///     Gets the id of the entity.
    /// </summary>
    public Guid Id { get; protected set; }
}