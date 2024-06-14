namespace SGPI.Application.Infrastructure;

public abstract class EndpointGroupBase
{
    public abstract string Name { get; }
    public abstract string[] Tags { get; }
    
    public abstract void Map(WebApplication app);
}