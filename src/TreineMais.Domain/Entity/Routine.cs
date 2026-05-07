namespace TreineMais.Domain.Entity;

public class Routine
{
    private readonly List<Training> _trainings = new();

    private Routine()
    {
    }

    public Routine(Guid userId, string name, string? description = null)
    {
        UserId = userId;
        Name = name;
        Description = description;
    }

    public int Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public IReadOnlyList<Training> Trainings => _trainings.AsReadOnly();

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Name cannot be null or whitespace.");

        Name = name;
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }

    public void AddTraining(Training training)
    {
        if (training is null)
            throw new ArgumentNullException(nameof(training));
        _trainings.Add(training);
    }
}