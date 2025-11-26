using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Entity;

public class Training
{
    public int Id { get; private set; }
    public Guid UserId { get; private set; } 
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public DateTime Date { get; private set; }
    
    private readonly List<TrainingExercise> _exercises = new();
    public IReadOnlyList<TrainingExercise> Exercises => _exercises.AsReadOnly();
    
    private Training() { }

    public Training(Guid userId, string name, string description, DateTime date)
    {
        UserId = userId;
        Name = name;
        Description = description;
        Date = date;
    }
    
    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Name cannot be null or whitespace.");
        
        Name = name;
    }

    public void UpdateDescription(string? descriptions) =>  Description = descriptions ?? string.Empty;
    
    public void AddExercise(TrainingExercise exercise)
    {
        if (exercise == null)
            throw new ArgumentNullException(nameof(exercise));
        
        _exercises.Add(exercise);
    }

    public void RemoveExercise(TrainingExercise exercise)
    {
        if (exercise == null)
            throw new ArgumentNullException(nameof(exercise));
        
        _exercises.Remove(exercise);
    }

    public void UpdateExerciseSets(TrainingExercise exercise, int newSets)
    {
        if (!this.Exercises.Contains(exercise))
            throw new InvalidOperationException("This exercise does not belong to this training.");
        
        exercise.UpdateSets(newSets);
    }

    public void UpdateExerciseReps(TrainingExercise exercise, int newReps)
    {
        if (!this.Exercises.Contains(exercise))
            throw new InvalidOperationException("This exercise does not belong to this training.");
        
        exercise.UpdateReps(newReps);
    }

    public void UpdateExerciseWeight(TrainingExercise exercise, Weight newWeight)
    {
        if (!this.Exercises.Contains(exercise))
            throw new InvalidOperationException("This exercise does not belong to this training.");
        
        exercise.UpdateWeight(newWeight);
    }
}

public class TrainingExercise
{
    public int ExerciseId { get; private set; }
    public int Sets { get; private set; }
    public int Reps { get; private set; }

    public Weight Weight { get; private set; } = null!;
    
    private TrainingExercise() { }

    public TrainingExercise(int exerciseId, int sets, int reps, Weight weight)
    {
        ExerciseId = exerciseId;
        Sets = sets;
        Reps = reps;
        Weight = weight;
    }

    internal void UpdateSets(int sets)
    {
        if (sets <= 0)
            throw new InvalidOperationException("Sets must be greater than zero");
        
        Sets = sets;
    }

    internal void UpdateReps(int reps)
    {
        if (reps <= 0)
            throw new InvalidOperationException("Reps must be greater than zero");
        
        Reps = reps;
    }

    internal void UpdateWeight(Weight weight) => Weight = weight ?? throw new ArgumentNullException(nameof(weight));
}