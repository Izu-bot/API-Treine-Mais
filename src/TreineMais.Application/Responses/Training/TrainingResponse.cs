using TreineMais.Application.Responses.Exercise;

namespace TreineMais.Application.Responses.Training;

public record TrainingResponse(
    int Id,
    string Name,
    string? Description);
    
public record TrainingWithExerciseResponse(
    int Id,
    string Name,
    string? Description,
    IEnumerable<TrainingExerciseResponse> Exercises);