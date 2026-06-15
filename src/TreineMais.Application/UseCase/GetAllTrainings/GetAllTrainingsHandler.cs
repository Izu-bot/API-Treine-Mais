using MediatR;
using TreineMais.Application.Helpers;
using TreineMais.Application.Responses.Exercise;
using TreineMais.Application.Responses.Training;
using TreineMais.Domain.Abstractions;

namespace TreineMais.Application.UseCase.GetAllTrainings;

public class GetAllTrainingsHandler : IRequestHandler<GetAllTrainingsQuery, PagedResult<TrainingWithExerciseResponse>>
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IUserRepository _userRepository;

    public GetAllTrainingsHandler(ITrainingRepository trainingRepository, IUserRepository userRepository)
    {
        _trainingRepository = trainingRepository;
        _userRepository = userRepository;
    }
    
    public async Task<PagedResult<TrainingWithExerciseResponse>> Handle(GetAllTrainingsQuery request, CancellationToken cancellationToken)
    {
        var userId = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new ArgumentException( $"{nameof(request.UserId)} Usuário não encontrado");
        
        var (allTrainings, totalCount) = await _trainingRepository.GetAllTrainingsAsync(request.Page, request.PageSize, userId.Id);

        var items = allTrainings
            .Select(t => new TrainingWithExerciseResponse(
                t.Id,
                t.Name,
                t.Description,
                t.Exercises.Select(e => new TrainingExerciseResponse(
                        e.ExerciseId,
                        e.Sets,
                        e.Reps,
                        e.Weight))
                    .ToList()))
            .ToList();

        return new PagedResult<TrainingWithExerciseResponse>(items, totalCount, request.Page, request.PageSize);
    }
}
