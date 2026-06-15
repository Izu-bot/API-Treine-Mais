using FluentValidation;
using MediatR;
using TreineMais.Application.Helpers;
using TreineMais.Application.Responses.Training;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;

namespace TreineMais.Application.UseCase.AddTraining;

public class AddTrainingHandler : IRequestHandler<AddTrainingCommand, TrainingResponse>
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IValidator<AddTrainingCommand> _validator;

    public AddTrainingHandler(
        ITrainingRepository trainingRepository,
        IValidator<AddTrainingCommand> validator)
    {
        _trainingRepository = trainingRepository;
        _validator = validator;
    }

    public async Task<TrainingResponse> Handle(AddTrainingCommand request, CancellationToken cancellationToken)
    {
        await ValidationHelper.ValidateAndThrowAsync(_validator, request);

        Training training = new(
            request.UserId,
            request.Name,
            request.Description ?? string.Empty,
            request.Date
            );

        await _trainingRepository.AddTrainingAsync(training);

        return new TrainingResponse(training.Id, training.Name, training.Description);
    }
}