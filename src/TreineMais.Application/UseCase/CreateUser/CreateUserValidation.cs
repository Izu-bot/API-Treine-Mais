using System;
using FluentValidation;

namespace TreineMais.Application.UseCase.CreateUser;

public class CreateUserValidation : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Email inválido.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é obrigatória.")
            .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.");
        // RuleFor(x => x.Gender)
        //     .NotEmpty().WithMessage("Gênero é obrigatório.");
        // RuleFor(x => x.BirthDate)
        //     .NotEmpty().WithMessage("Data de nascimento é obrigatória.");
        // RuleFor(x => x.Height)
        //     .GreaterThan(0).WithMessage("Altura deve ser maior que zero.");
        // RuleFor(x => x.Weight)
        //     .GreaterThan(0).WithMessage("Peso deve ser maior que zero.");
        // RuleFor(x => x.Goals)
        //     .NotEmpty().WithMessage("Objetivos são obrigatórios.");
    }
}
