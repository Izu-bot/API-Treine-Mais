namespace TreineMais.API.Endpoints;

internal static class SyncEndpoint
{
    internal static IEndpointRouteBuilder MapSync(IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("/sync", Sync);

        return endpoint;
    }

    private static async Task<IResult> Sync()
    {
    }
}