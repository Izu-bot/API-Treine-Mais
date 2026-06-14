using MediatR;
using Microsoft.AspNetCore.Mvc;
using TreineMais.API.Requests.Exercise;
using TreineMais.API.Utils;
using TreineMais.Application.UseCase.CreateExercise;

namespace TreineMais.API.Endpoints;

public static class ExerciseEndpoint
{
    public static IEndpointRouteBuilder MapExerciseEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("exercises");

        group.MapPost("/create-exercise", CreateExercise);
        
        return app;
    }

    private static async Task<IResult> CreateExercise(
        [FromBody] ExerciseRequest request,
        [FromServices] IMediator mediator,
        HttpContext httpContext)
    {
        var userId = httpContext.User.GetUserId();

        var command = new CreateExerciseCommand
        {
            UserId = userId,
            Name = request.Name,
            Description = request.Description,
            Category = request.Category
        };
        
        var result = await mediator.Send(command);
        
        return Results.Created($"/exercise/{result.ExerciseId}", result);
    }
}