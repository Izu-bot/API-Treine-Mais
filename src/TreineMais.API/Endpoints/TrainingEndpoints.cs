using MediatR;
using Microsoft.AspNetCore.Mvc;
using TreineMais.API.Requests.Training;
using TreineMais.API.Requests.TrainingExercise;
using TreineMais.API.Utils;
using TreineMais.Application.UseCase.AddExercise;
using TreineMais.Application.UseCase.AddTraining;
using TreineMais.Application.UseCase.GetAllTrainings;

namespace TreineMais.API.Endpoints;

internal static class TrainingEndpoints
{
    internal static IEndpointRouteBuilder MapTrainingEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("training");
        
        group.MapPost("/create-training", CreateTraining);
        group.MapPost("/add-exercise", AddExerciseToTraining);
        group.MapGet("/all-trainings", GetAllTrainings);
        
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

    private static async Task<IResult> AddExerciseToTraining(
        [FromBody] TrainingExerciseRequest request,
        [FromServices] IMediator mediator)
    {
        var command = new AddExerciseToTrainingCommand
        {
            ExerciseId = request.ExerciseId,
            TrainingId = request.TrainingId,
            Sets = request.Sets,
            Reps = request.Reps,
            Weight = request.Weight
        };
        
        var result = await mediator.Send(command);
        
        return Results.Created($"training/{result.ExerciseId}", result);
    }

    private static async Task<IResult> GetAllTrainings(
        [FromServices] IMediator mediator,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await mediator.Send(new GetAllTrainingsQuery(page, pageSize));
        
        return Results.Ok(result);
    }
}