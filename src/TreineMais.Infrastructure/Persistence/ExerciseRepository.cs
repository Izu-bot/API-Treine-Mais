using Microsoft.EntityFrameworkCore;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;
using TreineMais.Infrastructure.Context;

namespace TreineMais.Infrastructure.Persistence;

internal class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public ExerciseRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
    
    public Task<Exercise?> GetByIdAsync(int id) => _dbContext.Exercises.AsNoTracking().FirstOrDefaultAsync(exercise => exercise.Id == id);
    public async Task<(IEnumerable<Exercise> Exercises, int TotalCount)> GetAllExerciseAsync(int page, int pageSize, Guid userId)
    {
        var query = _dbContext.Exercises
            .AsNoTracking()
            .Where(exercise => exercise.UserId == userId);
        
        var totalCount = await query.CountAsync();

        var item = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (item, totalCount);
    }

    public Task<bool> ExistsAsync(int id) =>  _dbContext.Exercises.AsNoTracking().AnyAsync(exercise => exercise.Id == id);

    public async Task AddAsync(Exercise exercise)
    {
        _dbContext.Exercises.Add(exercise);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Exercise exercise)
    {
        _dbContext.Exercises.Update(exercise);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Exercise exercise)
    {
        _dbContext.Exercises.Remove(exercise);
        await _dbContext.SaveChangesAsync();
    }
}