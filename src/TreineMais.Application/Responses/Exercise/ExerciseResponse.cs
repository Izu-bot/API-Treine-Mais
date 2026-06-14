using TreineMais.Domain.ValueObject;

namespace TreineMais.Application.Responses.Exercise;

public record ExerciseResponse(
    int ExerciseId,
    Guid UserId,
    string Name,
    string Description,
    string Category);

public record TrainingExerciseResponse(
    int ExerciseId,
    int Sets,
    int Reps,
    Weight Weight);