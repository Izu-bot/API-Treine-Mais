namespace TreineMais.Application.Responses.Training;

public record TrainingResponse(
    int Id,
    string Name,
    string? Description);