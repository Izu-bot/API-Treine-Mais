using MediatR;
using TreineMais.Application.Helpers;
using TreineMais.Application.Responses.Exercise;
using TreineMais.Application.Responses.Training;
using TreineMais.Domain.Abstractions;

namespace TreineMais.Application.UseCase.GetAllTrainings;

public class GetAllTrainingsHandler : IRequestHandler<GetAllTrainingsQuery, PagedResult<TrainingWithExerciseResponse>>
{
    private readonly ITrainingRepository _trainingRepository;

    public GetAllTrainingsHandler(ITrainingRepository trainingRepository)
    {
        _trainingRepository = trainingRepository;
    }
    
    public async Task<PagedResult<TrainingWithExerciseResponse>> Handle(GetAllTrainingsQuery request, CancellationToken cancellationToken)
    {
        var (allTrainings, totalCount) = await _trainingRepository.GetAllTrainingsAsync(request.Page, request.PageSize);

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
