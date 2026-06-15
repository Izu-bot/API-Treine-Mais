using MediatR;
using TreineMais.Application.Helpers;
using TreineMais.Application.Responses.Exercise;

namespace TreineMais.Application.UseCase.GetAllExercises;

public record GetAllExercisesQuery(Guid UserId, int Page = 1, int PageSize = 10)
    : IRequest<PagedResult<ExerciseResponse>>
{
    public int Page { get; init; } = Math.Max(1, Page);
    public int PageSize { get; init; } = Math.Clamp(PageSize, 1, 10);
}