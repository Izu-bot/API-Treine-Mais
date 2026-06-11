namespace TreineMais.API.Requests.Exercise;

public record TrainingExerciseRequest(
    int Sets,
    int Reps,
    int Weight);