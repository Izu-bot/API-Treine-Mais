using TreineMais.Application.DTO.Profile;

namespace TreineMais.Application.DTO.User;

public record UserRequest(string Email, string Password, ProfileRequest Profile);