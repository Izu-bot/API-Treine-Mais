using FluentValidation;
using MediatR;
using TreineMais.Application.Exceptions;
using TreineMais.Application.Helpers;
using TreineMais.Application.Responses.Exercise;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;

namespace TreineMais.Application.UseCase.CreateExercise;

public class CreateExerciseHandler : IRequestHandler<CreateExerciseCommand, ExerciseResponse>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserRepository _userRepository;
    private readonly IValidator<CreateExerciseCommand> _validator;

    public CreateExerciseHandler(
        IExerciseRepository exerciseRepository,
        IUserRepository userRepository,
        IValidator<CreateExerciseCommand> validator)
    {
        _exerciseRepository = exerciseRepository;
        _userRepository = userRepository;
        _validator = validator;
    }
    
    public async Task<ExerciseResponse> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
    {
        await ValidationHelper.ValidateAndThrowAsync(_validator, request);

        var userId = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new NotFoundException($"Usuário com ID {request.UserId} não foi encontrado.");
        
        Exercise exercise = new(
            userId.Id,
            request.Name ?? string.Empty,
            request.Description ?? string.Empty,
            request.Category ?? string.Empty);

        await _exerciseRepository.AddAsync(exercise);

        return new ExerciseResponse(
            exercise.Id,
            exercise.UserId,
            exercise.Name,
            exercise.Description,
            exercise.Category);
    }
}