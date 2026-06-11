using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sprache;
using TreineMais.API.Requests.Training;
using TreineMais.API.Utils;
using TreineMais.Application.UseCase.AddTraining;

namespace TreineMais.API.Endpoints;

internal static class TrainingEndpoints
{
    internal static IEndpointRouteBuilder MapTrainingEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("training");
        
        group.MapPost("/create-training", CreateTraining);
        
        return app;
    }

    private static async Task<IResult> CreateTraining(
        HttpContext httpContext,
        [FromBody] TrainingRequest request,
        [FromServices] IMediator mediator)
    {
        var user = httpContext.User.GetUserId();
        
        var command = new AddTrainingCommand
        {
            UserId = user,
            Name = request.Name,
            Description = request.Description,
            Date = DateTime.UtcNow,
        };

        var result = await mediator.Send(command);
        
        return Results.Created($"training/{result.Id}", result);
    }
}