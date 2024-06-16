namespace SGPI.Domain.Entities.Abstract;

public abstract class AuditableEntity : Entity
{
    protected AuditableEntity()
    {
    }

    /// <summary>
    ///     Creates an instance of the Description class based on the provided value.
    /// </summary>
    /// <param name="id"> The id of the entity.</param>
    protected AuditableEntity(Guid id) : base(id)
    {
    }

    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    ///     Dates the time the entity was modified.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    ///     Indicates if the entity is enabled
    /// </summary>
    public bool Enabled { get; protected set; } = true;

    /// <summary>
    ///     Indicates if the entity is disabled
    /// </summary>
    public bool IsDisabled => !Enabled;
}