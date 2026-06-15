using TreineMais.Application.Responses.Profile;

namespace TreineMais.Application.Responses.User;

public record UserResponse(Guid UserId, string Email, ProfileResponse Profile);