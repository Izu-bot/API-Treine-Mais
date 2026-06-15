namespace TreineMais.API.Requests.Training;

public record TrainingRequest(
    string Name,
    string? Description
);