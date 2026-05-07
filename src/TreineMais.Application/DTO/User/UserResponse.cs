using TreineMais.Application.DTO.Profile;

namespace TreineMais.Application.DTO.User;

public record UserResponse(Guid UserId, string Email, ProfileResponse Profile);