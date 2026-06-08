using FluentValidation;
using MediatR;
using TreineMais.Application.DTO.Trainings;
using TreineMais.Domain.Abstractions;

namespace TreineMais.Application.UseCase.AddTraining;

public class AddTrainingHandler : IRequestHandler<AddTrainingCommand, TrainingResponse>
{
    private readonly ITrainingRepository _repository;
    private readonly IValidator<AddTrainingCommand> _validator;

    public AddTrainingHandler(ITrainingRepository repository, IValidator<AddTrainingCommand> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<TrainingResponse> Handle(AddTrainingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}