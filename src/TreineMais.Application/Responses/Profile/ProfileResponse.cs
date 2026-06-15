namespace TreineMais.Application.Responses.Profile;

public record ProfileResponse(
    string Name,
    string? Gender,
    string? BirthDate,
    float? Height,
    float? Weight,
    string? Goals
);