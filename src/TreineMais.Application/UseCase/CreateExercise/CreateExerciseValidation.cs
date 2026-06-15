using FluentValidation;

namespace TreineMais.Application.UseCase.CreateExercise;

public class CreateExerciseValidation : AbstractValidator<CreateExerciseCommand>
{
    public CreateExerciseValidation()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
            .WithMessage("O usuário é obrigatório.");

        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Um nome é obrigatório.")
            .MinimumLength(4);
    }
}