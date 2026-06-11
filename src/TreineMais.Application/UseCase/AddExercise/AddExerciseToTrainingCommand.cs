using MediatR;
using TreineMais.Application.Responses.Exercise;

namespace TreineMais.Application.UseCase.AddExercise;

public record AddExerciseToTrainingCommand : IRequest<TrainingExerciseResponse>
{
    public int TrainingId { get; init; }
    public int ExerciseId { get; init; }
    public int Sets { get; init; }
    public int Reps { get; init; }
    public int Weight {get; init;}
}