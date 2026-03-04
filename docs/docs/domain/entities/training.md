# Training

**Namespace:** `TreineMais.Domain.Entity`

`Training` representa uma sessão de treino realizada por um usuário em uma determinada data. Contém uma lista de exercícios (`TrainingExercise`) com suas respectivas configurações de séries, repetições e carga.

---

## Propriedades

| Propriedade | Tipo | Descrição |
|---|---|---|
| `Id` | `int` | Identificador único do treino |
| `UserId` | `Guid` | Identificador do usuário dono do treino |
| `Name` | `string` | Nome do treino (ex: "Treino A - Peito e Tríceps") |
| `Description` | `string?` | Descrição opcional do treino |
| `Date` | `DateTime` | Data em que o treino foi ou será realizado |
| `Exercises` | `IReadOnlyList<TrainingExercise>` | Lista imutável de exercícios do treino |

---

## Construtor

```csharp
public Training(Guid userId, string name, string description, DateTime date)
```

---

## Métodos

### Gerenciamento de Exercícios

#### `AddExercise(TrainingExercise exercise)`
Adiciona um exercício ao treino. Lança `ArgumentNullException` se `exercise` for `null`.

#### `RemoveExercise(TrainingExercise exercise)`
Remove um exercício do treino. Lança `ArgumentNullException` se `exercise` for `null`.

---

### Atualização de Exercícios

Todos os métodos abaixo validam se o `exercise` pertence ao treino antes de aplicar a alteração. Caso contrário, lançam `InvalidOperationException("This exercise does not belong to this training.")`.

#### `UpdateExerciseSets(TrainingExercise exercise, int newSets)`
Atualiza o número de séries de um exercício.

#### `UpdateExerciseReps(TrainingExercise exercise, int newReps)`
Atualiza o número de repetições de um exercício.

#### `UpdateExerciseWeight(TrainingExercise exercise, Weight newWeight)`
Atualiza a carga de um exercício.

---

### Atualização de Dados do Treino

#### `UpdateName(string name)`
Atualiza o nome do treino. Lança `InvalidOperationException` se `name` for `null` ou espaços em branco.

#### `UpdateDescription(string? description)`
Atualiza a descrição. Aceita `null`, armazenando `string.Empty`.

---

## Exemplo de Uso

```csharp
var training = new Training(
    userId: user.Id,
    name: "Treino A - Peito",
    description: "Foco em peitoral e tríceps",
    date: DateTime.UtcNow
);

var exercise = new TrainingExercise(
    exerciseId: supino.Id,
    sets: 4,
    reps: 10,
    weight: new Weight(80m)
);

training.AddExercise(exercise);
training.UpdateExerciseSets(exercise, 5);
training.UpdateExerciseWeight(exercise, new Weight(85m));
training.RemoveExercise(exercise);
```

---

---

# TrainingExercise

`TrainingExercise` é uma entidade de associação que representa um exercício dentro de um treino, com suas configurações específicas de execução.

!!! info "Encapsulamento"
    Os métodos de atualização (`UpdateSets`, `UpdateReps`, `UpdateWeight`) são `internal` — só podem ser chamados pela entidade `Training`, garantindo que as regras de pertencimento sejam sempre validadas.

---

## Propriedades

| Propriedade | Tipo | Descrição |
|---|---|---|
| `ExerciseId` | `int` | Referência ao `Exercise` cadastrado |
| `Sets` | `int` | Número de séries |
| `Reps` | `int` | Número de repetições por série |
| `Weight` | `Weight` | Carga utilizada no exercício |

---

## Construtor

```csharp
public TrainingExercise(int exerciseId, int sets, int reps, Weight weight)
```

---

## Métodos Internos

> Estes métodos são acessíveis apenas por `Training`.

#### `UpdateSets(int sets)`
Atualiza as séries. Lança `InvalidOperationException` se `sets <= 0`.

#### `UpdateReps(int reps)`
Atualiza as repetições. Lança `InvalidOperationException` se `reps <= 0`.

#### `UpdateWeight(Weight weight)`
Atualiza a carga. Lança `ArgumentNullException` se `weight` for `null`.

---

## Observações

- `TrainingExercise` não possui `Id` próprio — é uma entidade dependente do agregado `Training`.
- A lista `Exercises` em `Training` é exposta como `IReadOnlyList<TrainingExercise>`, impedindo modificações diretas externas.
- O design `internal` dos métodos de `TrainingExercise` força que toda mutação passe pela validação de pertencimento definida em `Training`.
