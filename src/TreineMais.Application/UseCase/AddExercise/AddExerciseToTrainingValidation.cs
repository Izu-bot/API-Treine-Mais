using FluentValidation;

namespace TreineMais.Application.UseCase.AddExercise;

public class AddExerciseToTrainingValidation : AbstractValidator<AddExerciseToTrainingCommand>
{
    public AddExerciseToTrainingValidation()
    {
        RuleFor(command => command.TrainingId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Você deve associar á um Treino.");
        
        RuleFor(command => command.ExerciseId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Um exercício existente é obrigatório");

        RuleFor(command => command.Sets)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Séries deve receber apenas números e deve ser maior que zero.");
        
        RuleFor(command => command.Reps)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Repetiçẽos devem receber apenas numeros e deve ser maior que zerio.");

        RuleFor(command => command.Weight)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Peso deve ser maior que zero.");
    }
}