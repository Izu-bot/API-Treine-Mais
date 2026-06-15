using MediatR;
using TreineMais.Application.Helpers;
using TreineMais.Application.Responses.Training;

namespace TreineMais.Application.UseCase.GetAllTrainings;

public record GetAllTrainingsQuery(int Page = 1, int PageSize = 10)
    : IRequest<PagedResult<TrainingWithExerciseResponse>>
{
    public int Page { get; init; } = Math.Max(1, Page);
    public int PageSize { get; init; } = Math.Clamp(PageSize, 1, 50);
}