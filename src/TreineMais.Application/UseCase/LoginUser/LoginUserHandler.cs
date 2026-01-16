using System;
using MediatR;
using TreineMais.Application.DTO.Auth;
using TreineMais.Application.Exceptions;
using TreineMais.Application.Security;
using TreineMais.Domain.Abstractions;

namespace TreineMais.Application.UseCase.LoginUser;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, AuthResponse>
{
    private readonly IUserRepository _repository;
    private readonly IHashPassword _hashPassword;
    private readonly IJwtGenerate _jwtGenerate;

    public LoginUserHandler(IUserRepository repository, IHashPassword hashPassword, IJwtGenerate jwtGenerate)
    {
        _repository = repository;
        _hashPassword = hashPassword;
        _jwtGenerate = jwtGenerate;
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

        // Salvar esse refresh em um banco de dados como o 
        // redis ou sqlite,
        // adicionar também uma data para expiração.
        string refreshToken = Guid.NewGuid().ToString();

        return new AuthResponse(
            accessToken,
            refreshToken
        );
    }
}
