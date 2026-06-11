namespace TreineMais.API.Endpoints;

internal static class MapAllEndpoints
{
    internal static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapAuthEndpoints();
        app.MapSyncEndpoint();
        app.MapTrainingEndpoint();

        return app;
    }
}