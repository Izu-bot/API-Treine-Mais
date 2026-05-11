using MediatR;
using Microsoft.AspNetCore.Mvc;
using TreineMais.API.Utils;
using TreineMais.Application.DTO.Profile;
using TreineMais.Application.UseCase.Sync;
using TreineMais.Application.UseCase.Sync.DTOs;

namespace TreineMais.API.Endpoints;

internal static class SyncEndpoint
{
    internal static IEndpointRouteBuilder MapSync(IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("/sync", Sync);

        return endpoint;
    }

    private static async Task<IResult> Sync(
        HttpContext httpContext,
        [FromBody] ProfileRequest request,
        [FromServices] ISender mediator
    )
    {
        var userId = httpContext.User.GetUserId();

        var result = await mediator.Send(
            new SyncCommand(
                userId,
                new SyncProfileDto(
                    request.Name,
                    request.Height,
                    request.Weight,
                    request.Goals,
                    request.UpdatedAt
                )
            )
        );

        return result.Success ? Results.Ok() : Results.Conflict(new { error = result.Message });
    }
}