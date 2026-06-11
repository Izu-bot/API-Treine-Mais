using FluentValidation;

namespace TreineMais.Application.UseCase.AddTraining;

public class AddTrainingValidation : AbstractValidator<AddTrainingCommand>
{
    public AddTrainingValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nome para o treino é obrigátoio.");
    }
}