using System;
using MediatR;
using TreineMais.Application.DTO.Auth;
using TreineMais.Application.Exceptions;
using TreineMais.Application.Security;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;

namespace TreineMais.Application.UseCase.LoginUser;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, AuthResponse>
{
    private readonly IUserRepository _repository;
    private readonly IHashPassword _hashPassword;
    private readonly IJwtGenerate _jwtGenerate;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public LoginUserHandler(
        IUserRepository repository,
        IJwtGenerate jwtGenerate,
        IHashPassword hashPassword,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _repository = repository;
        _hashPassword = hashPassword;
        _jwtGenerate = jwtGenerate;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByEmailAsync(request.Email)
            ?? throw new BusinessException("Email não encontrado ou não existente.");
        
        _hashPassword.VerifyPassword(request.Password, user.Login.Password.Value);

        // Passar o objeto user que já está validado tanto na existência dos dados
        // quanto na verificação da senha parece mais simples do que ter que castar
        // para um dado do tipo AuthRequest.
        string accessToken = _jwtGenerate.GenerateJwt(user);

        var refreshToken = new RefreshToken(user.Id);
        
        await _refreshTokenRepository.Add(refreshToken);

        return new AuthResponse(
            accessToken,
            refreshToken.Token
        );
    }
}
