namespace TreineMais.API.Requests.Profile;

public record ProfileRequest(
    string Name,
    string Gender,
    DateTime BirthDate,
    float Height,
    float Weight,
    string? Goals,
    DateTime? UpdatedAt
);