using MediatR;
using TreineMais.Application.DTO.Trainings;

namespace TreineMais.Application.UseCase.AddTraining;

public record AddTrainingCommand : IRequest<TrainingResponse>
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; } = string.Empty;
    public int Sets { get; init; }
    public int Reps { get; init; }
    public float Weight { get; init; }
}