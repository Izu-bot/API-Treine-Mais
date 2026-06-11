using FluentValidation;
using MediatR;
using TreineMais.Application.Exceptions;
using TreineMais.Application.Helpers;
using TreineMais.Application.Responses.Exercise;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Application.UseCase.AddExercise;

public class AddExerciseToTrainingHandler : IRequestHandler<AddExerciseToTrainingCommand, TrainingExerciseResponse>
{
    private readonly IValidator<AddExerciseToTrainingCommand> _validator;
    private readonly ITrainingRepository _trainingRepository;
    private readonly IExerciseRepository _exerciseRepository;

    public AddExerciseToTrainingHandler(
        IValidator<AddExerciseToTrainingCommand> validator,
        ITrainingRepository trainingRepository,
        IExerciseRepository exerciseRepository)
    {
        _validator = validator;
        _trainingRepository = trainingRepository;
        _exerciseRepository = exerciseRepository;
    }
    
    public async Task<TrainingExerciseResponse> Handle(AddExerciseToTrainingCommand request, CancellationToken cancellationToken)
    {
        await ValidationHelper.ValidateAndThrowAsync(_validator, request);

        var training = await _trainingRepository.GetTrainingByIdAsync(request.TrainingId)
            ?? throw new NotFoundException($"Treino {request.TrainingId} não encontrado.");

        var _ = await _exerciseRepository.GetByIdAsync(request.ExerciseId)
            ?? throw new NotFoundException($"Exercício {request.ExerciseId} não encontrado.");

        TrainingExercise trainingExercise = new(
            request.ExerciseId,
            request.Sets,
            request.Reps,
            new Weight(request.Weight));
        
        training.AddExercise(trainingExercise);

        await _trainingRepository.UpdateTrainingAsync(training);

        return new TrainingExerciseResponse(
            trainingExercise.ExerciseId,
            trainingExercise.Sets,
            trainingExercise.Reps,
            trainingExercise.Weight);
    }
}