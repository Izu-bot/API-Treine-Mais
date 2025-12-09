using System;
using MediatR;
using TreineMais.Application.DTO.Profile;
using TreineMais.Application.DTO.User;
using TreineMais.Application.Security;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Application.UseCase.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
{
    private readonly IUserRepository _repository;
    private readonly IHashPassword _hashPassword;

    public CreateUserHandler(IUserRepository repository, IHashPassword hashPassword)
    {
        _repository = repository;
        _hashPassword = hashPassword;
    }

    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Email email = new(request.Email);

        var hashedString = _hashPassword.HashPassword(request.Password);
        Password hashedPassword = new(hashedString);

        Login login = new(email, hashedPassword);

        var user = new User(login);

        if (!Enum.TryParse<Gender>(request.Gender, true, out var gender))
            throw new ArgumentException($"Gênero inválido {gender}");

        Profile profile = new(
            user.Id,
            request.Name,
            gender,
            request.BirthDate,
            new Height(request.Height),
            new Weight(request.Weight),
            request.Goals
        );

        user.UpdateProfile(profile);

        await _repository.CreateAsync(user);

        return new UserResponse(
            user.Id,
            user.Login.Email.Value,
            new ProfileResponse(
                profile.Name,
                profile.Gender.GetDisplayname(),
                profile.BirthDate.ToString("d"),
                profile.Height.Value,
                profile.Weight.Value,
                profile.Goals
            )
        );
    }
}
