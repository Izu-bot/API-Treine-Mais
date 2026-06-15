namespace TreineMais.API.Requests.TrainingExercise;

internal record TrainingExerciseRequest(
    int TrainingId,
    int ExerciseId,
    int Sets,
    int Reps,
    int Weight);