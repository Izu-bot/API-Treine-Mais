using TreineMais.Domain.Entity;

namespace TreineMais.Domain.Abstractions;

public interface ITrainingRepository
{
    Task AddTrainingAsync(Training training);
    Task RemoveTrainingAsync(Training training);
    Task UpdateTrainingAsync(Training training);
    Task<Training?> GetTrainingByIdAsync(int id);
    Task<(IEnumerable<Training>, int totalCount)> GetAllTrainingsAsync(int page, int pageSize, Guid userId);
}