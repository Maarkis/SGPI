using System.Reflection;

namespace SGPI.Application.Infrastructure;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group) =>
        app
            .MapGroup($"/api/{group.Name.ToLowerInvariant()}")
            .WithTags(group.Tags)
            .WithOpenApi();


    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(EndpointGroupBase);

        var assembly = Assembly.GetExecutingAssembly();

        var endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
    
    public static WebApplication MapRedirectToDocs(this WebApplication app)
    {
        app.Map("/", () => Results.Redirect($"/{Config.UrlDocs}"));
        return app;
    }
}
