using MediatR;
using TreineMais.Application.Responses.Exercise;

namespace TreineMais.Application.UseCase.CreateExercise;

public record CreateExerciseCommand : IRequest<ExerciseResponse>
{
    public Guid UserId { get; init; }
    public string? Name { get; init; } = string.Empty;
    public string? Description { get; init; } = string.Empty;
    public string? Category { get; init; } = string.Empty;
}