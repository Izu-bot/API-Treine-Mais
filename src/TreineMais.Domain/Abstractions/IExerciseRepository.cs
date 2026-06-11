using TreineMais.Domain.Entity;

namespace TreineMais.Domain.Abstractions;

public interface IExerciseRepository
{
    Task<Exercise?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task AddAsync(Exercise exercise);
    Task UpdateAsync(Exercise exercise);
    Task DeleteAsync(Exercise exercise);
}