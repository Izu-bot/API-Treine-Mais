using MediatR;
using TreineMais.Application.Exceptions;
using TreineMais.Application.Helpers;
using TreineMais.Application.Responses.Exercise;
using TreineMais.Domain.Abstractions;

namespace TreineMais.Application.UseCase.GetAllExercises;

public class GetAllExercisesHandler : IRequestHandler<GetAllExercisesQuery, PagedResult<ExerciseResponse>>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserRepository _userRepository;

    public GetAllExercisesHandler(IExerciseRepository exerciseRepository, IUserRepository userRepository)
    {
        _exerciseRepository = exerciseRepository;
        _userRepository = userRepository;
    }
    
    public async Task<PagedResult<ExerciseResponse>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
    {
        var userId = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new ArgumentException($"{nameof(request.UserId)} Usuário não encontrado");
        
        var (allExercises, totalCount) = await _exerciseRepository.GetAllExerciseAsync(request.Page, request.PageSize, userId.Id);

        var item = allExercises.Select(t => new ExerciseResponse(
            t.Id,
            t.UserId,
            t.Name,
            t.Description,
            t.Category))
            .ToList();
        
        return new PagedResult<ExerciseResponse>(item, totalCount, request.Page, request.PageSize);
    }
}