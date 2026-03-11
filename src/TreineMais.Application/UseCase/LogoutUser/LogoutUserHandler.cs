using MediatR;
using TreineMais.Application.DTO.Auth;
using TreineMais.Application.Exceptions;
using TreineMais.Domain.Abstractions;

namespace TreineMais.Application.UseCase.LogoutUser;

public class LogoutUserHandler : IRequestHandler<LogoutUserCommand, LogoutResponse>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public LogoutUserHandler(IRefreshTokenRepository refreshTokenRepository)
    {
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<LogoutResponse> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepository.GetByToken(request.RefreshToken);

        if (refreshToken == null || refreshToken.IsExpired || refreshToken.IsRevoked)
            throw new RefreshTokenRevokedOrNonExistent("Refresh token revoked");
        
        await _refreshTokenRepository.Revoke(refreshToken);

        return new LogoutResponse(
            "You have been logged out."
        );
    }
}