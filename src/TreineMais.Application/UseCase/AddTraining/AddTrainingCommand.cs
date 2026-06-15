using MediatR;
using TreineMais.Application.Responses.Training;

namespace TreineMais.Application.UseCase.AddTraining;

public record AddTrainingCommand : IRequest<TrainingResponse>
{
    public Guid UserId { get; set; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; } = string.Empty;
    public DateTime Date { get; init; }
}