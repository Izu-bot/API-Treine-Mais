namespace TreineMais.Application.DTO.Trainings;

public record TrainingResponse(
    int Id,
    string Name,
    string? Description,
    TrainingExercisesResponse TrainingExercises);

public record TrainingExercisesResponse(
    int ExerciseId,
    int Sets,
    int Reps,
    float Weight);