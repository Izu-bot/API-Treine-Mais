using MediatR;
using TreineMais.Application.DTO.Auth;

namespace TreineMais.Application.UseCase.ConfirmRefreshToken;

public class RefreshTokenCommand : IRequest<AuthResponse>
{
    public string Token { get; init; } = string.Empty;
}