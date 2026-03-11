using MediatR;
using TreineMais.Application.DTO.Auth;
using TreineMais.Application.Exceptions;
using TreineMais.Application.Security;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;

namespace TreineMais.Application.UseCase.ConfirmRefreshToken;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, AuthResponse>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IJwtGenerate _jwtGenerate;
    private readonly IUserRepository _userRepository;

    public RefreshTokenHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IJwtGenerate jwtGenerate,
        IUserRepository userRepository
        )
    {
        _refreshTokenRepository = refreshTokenRepository;
        _jwtGenerate = jwtGenerate;
        _userRepository = userRepository;
    }
    
    public async Task<AuthResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepository.GetByToken(request.Token);
        if (refreshToken == null || refreshToken.IsExpired || refreshToken.IsRevoked)
            throw new RefreshTokenRevokedOrNonExistent("Refresh token revoked");
        
        await _refreshTokenRepository.Revoke(refreshToken);

        var newRefreshToken = new RefreshToken(refreshToken.UserId);

        await _refreshTokenRepository.Add(newRefreshToken);
        
        var user = await _userRepository.GetByIdAsync(refreshToken.UserId);
        
        string accessToken = _jwtGenerate.GenerateJwt(user!);

        return new AuthResponse(
            AccessToken: accessToken,
            RefreshToken: newRefreshToken.Token
        );
    }
}