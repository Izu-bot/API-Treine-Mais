using MediatR;
using TreineMais.Application.Responses.Auth;

namespace TreineMais.Application.UseCase.ConfirmRefreshToken;

public class RefreshTokenCommand : IRequest<AuthResponse>
{
    public string Token { get; init; } = string.Empty;
}