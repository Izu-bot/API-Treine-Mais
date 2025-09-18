using TreineMais.Domain.Entity;

namespace TreineMais.UnitTests.Entity;

public class RoutineTests
{
    [Fact]
    public void Constructor_CreateNewRoutine_NotNull()
    {
        Routine routine = new(1, "Treino de segunda-feira");
        Assert.NotNull(routine);
    }

    [Fact]
    public void Routine_MustUpdateNameAndDescriptions()
    {
        Routine routine = new(1, "Treino de segunda-feira", "Treino de força");
        string newName = "Treine de quarta-feira";
        string newDescription = "Treine aerobico";
        
        routine.UpdateName(newName);
        routine.UpdateDescription(newDescription);
        
        Assert.Equal(newName, routine.Name);
        Assert.Equal(newDescription, routine.Description);
    }

    [Fact]
    public void Add_TrainingToRoutine()
    {
        Routine routine = new(1, "Treino de segunda-feira", "Treino de força");
        Training training = new(1, "Treino de Peito", "Treino pesado, com poucas pausas para hipertrofia",
            DateTime.Now);
        
        routine.AddTraining(training);
        
        Assert.Contains(training, routine.Trainings);
    }
}