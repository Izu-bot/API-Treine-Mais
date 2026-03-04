using FluentValidation;
using MediatR;
using TreineMais.Application.Abstractions;
using TreineMais.Application.DTO.Profile;
using TreineMais.Application.DTO.User;
using TreineMais.Application.Exceptions;
using TreineMais.Application.Helpers;
using TreineMais.Application.Security;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Application.UseCase.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
{
    private readonly IUserRepository _repository;
    private readonly IEmailSender _emailSender;
    private readonly IHashPassword _hashPassword;
    private readonly IValidator<CreateUserCommand> _validator;
    public CreateUserHandler(IUserRepository repository,
                             IHashPassword hashPassword,
                             IValidator<CreateUserCommand> validator,
                             IEmailSender emailSender)
    {
        _repository = repository;
        _hashPassword = hashPassword;
        _validator = validator;
        _emailSender = emailSender;
    }

    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await ValidationHelper.ValidateAndThrowAsync(_validator, request);

        Email email = new(request.Email);

        var hashedString = _hashPassword.HashPassword(request.Password);
        Password hashedPassword = new(hashedString);

        Login login = new(email, hashedPassword);

        var user = new User(login);
        
        if (!Enum.TryParse<Gender>(request.Gender, true, out var gender))
            throw new GenderInvalidException(request.Gender);

        Profile profile = new(
            user.Id,
            request.Name,
            gender,
            request.BirthDate,
            new Height(request.Height),
            new Weight(request.Weight),
            request.Goals
        );

        var link = $"http://10.0.2.2:5297/auth/confirm-email?token={user.EmailConfirmedToken}";

        await _emailSender.SendAsync(
            request.Email,
            "Confirme seu e-mail",
            $"Clique no link para confirmar {link}"
        );

        user.UpdateProfile(profile);

        await _repository.CreateAsync(user);

        return new UserResponse(
            user.Id,
            user.Login.Email.Value,
            new ProfileResponse(
                profile.Name,
                profile.Gender?.GetDisplayname(),
                profile.BirthDate?.ToString("d"),
                profile.Height?.Value,
                profile.Weight?.Value,
                profile.Goals
            )
        );
    }
}
