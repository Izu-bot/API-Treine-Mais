namespace TreineMais.Application.DTO.Trainings;

public record TrainingRequest(
    string Name,
    string? Description,
    TrainingExercisesRequest TrainingExercises
);

public record TrainingExercisesRequest(
    int Sets,
    int Reps,
    float Weight);