using Microsoft.EntityFrameworkCore;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;
using TreineMais.Infrastructure.Context;

namespace TreineMais.Infrastructure.Persistence;

internal class TrainingRepository : ITrainingRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TrainingRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task AddTrainingAsync(Training training)
    {
        _dbContext.Trainings.Add(training);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveTrainingAsync(Training training)
    {
        _dbContext.Trainings.Remove(training);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateTrainingAsync(Training training)
    {
        _dbContext.Trainings.Update(training);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Training?> GetTrainingByIdAsync(int id)
    {
        return await _dbContext.Trainings
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<(IEnumerable<Training>, int totalCount)> GetAllTrainingsAsync(int page, int pageSize)
    {
        var query = _dbContext.Trainings.AsNoTracking();

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(t => t.Exercises)
            .ToListAsync();
        
        return (items, totalCount);
    }
}