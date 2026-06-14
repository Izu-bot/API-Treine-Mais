namespace TreineMais.API.Requests.Exercise;

internal record ExerciseRequest(
    string Name,
    string? Description,
    string? Category);