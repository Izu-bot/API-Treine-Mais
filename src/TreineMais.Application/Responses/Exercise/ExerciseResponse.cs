using TreineMais.Domain.ValueObject;

namespace TreineMais.Application.Responses.Exercise;

public record TrainingExerciseResponse(
    int ExerciseId,
    int Sets,
    int Reps,
    Weight Weight);