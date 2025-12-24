using System;
using MediatR;
using TreineMais.Application.Exceptions;
using TreineMais.Domain.Abstractions;

namespace TreineMais.Application.UseCase.ConfirmEmail;

public class ConfirmEmailHandler
{
    private readonly IUserRepository _repository;

    public ConfirmEmailHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(ConfirmEmailCommand command)
    {
        var user = await _repository.GetByEmailConfirmationTokenAsync(command.Token)
        ?? throw new BusinessException("Token inválido.");
        
        user.ConfirmEmail(command.Token);

        await _repository.UpdateAsync(user);
    }
}
