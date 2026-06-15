using TreineMais.API.Requests.Profile;

namespace TreineMais.API.Requests.User;

public record UserRequest(string Email, string Password, ProfileRequest Profile);