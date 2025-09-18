using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.UnitTests.Entity;

public class TrainingTests
{
    [Fact]
    public void Constructor_CreateNewTraining_NotNull()
    {
        Training training = new(1, "Treino de Peito", "Treino pesado, com poucas pausas para hipertrofia",
            DateTime.Now);
        Assert.NotNull(training);
    }

    [Fact]
    public void Update_Name_Description()
    {
        Training training = new(1, "Treino de Peito", "Treino pesado, com poucas pausas para hipertrofia",
            DateTime.Now);

        string newName = "Treino de Ombro";
        string newDescription = "Treino de Ombro";
        
        training.UpdateName(newName);
        training.UpdateDescription(newDescription);
        
        Assert.Equal(newName, training.Name);
        Assert.Equal(newDescription, training.Description);
    }

    [Fact]
    public void Add_NewExercise()
    {
        TrainingExercise trainingExercise = new(1, 4, 12, new Weight(40.0f));
        Training training = new(1, "Treino de Peito", "Treino pesado, com poucas pausas para hipertrofia",
            DateTime.Now);
        
        training.AddExercise(trainingExercise);

        Assert.Contains(trainingExercise, training.Exercises);
    }

    [Fact]
    public void Remove_Exercise()
    {
        TrainingExercise trainingExercise = new(1, 4, 12, new Weight(40.0f));
        Training training = new(1, "Treino de Peito", "Treino pesado, com poucas pausas para hipertrofia",
            DateTime.Now);
        
        training.RemoveExercise(trainingExercise);
        
        Assert.DoesNotContain(trainingExercise, training.Exercises);
    }

    [Fact]
    public void Update_ExerciseValuesTraining()
    {
        TrainingExercise trainingExercise = new(1, 4, 12, new Weight(40.0f));
        Training training = new(1, "Treino de Peito", "Treino pesado, com poucas pausas para hipertrofia",
            DateTime.Now);
        
        training.AddExercise(trainingExercise);

        int newSets = 8;
        int newReps = 10;
        Weight newWeight = new(46.0f);
        
        training.UpdateExerciseSets(trainingExercise, newSets);
        training.UpdateExerciseReps(trainingExercise, newReps);
        training.UpdateExerciseWeight(trainingExercise, newWeight);
        
        Assert.Equal(newSets, trainingExercise.Sets);
        Assert.Equal(newReps, trainingExercise.Reps);
        Assert.Equal(newWeight, trainingExercise.Weight);
    }
}