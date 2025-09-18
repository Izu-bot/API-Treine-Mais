using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Entity;

public class Routine
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    private readonly List<Training> _trainings = new();
    public IReadOnlyList<Training> Trainings => _trainings.AsReadOnly();
    
    private Routine() { }

    public Routine(int userId, string name, string? description = null)
    {
        UserId = userId;
        Name = name;
        Description = description;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Name cannot be null or whitespace.");
        
        Name = name;
    }
    
    public void UpdateDescription(string? description) => Description = description;

    public void AddTraining(Training training)
    {
        if (training is null)
            throw new ArgumentNullException(nameof(training));
        _trainings.Add(training);
    }
}
