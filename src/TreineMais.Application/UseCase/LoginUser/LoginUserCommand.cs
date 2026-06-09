using MediatR;
using TreineMais.Application.Responses.Auth;

namespace TreineMais.Application.UseCase.LoginUser;

public record LoginUserCommand : IRequest<AuthResponse>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}