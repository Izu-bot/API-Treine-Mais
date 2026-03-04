# Exercise

**Namespace:** `TreineMais.Domain.Entity`

`Exercise` representa um exercício físico cadastrado por um usuário. Contém informações descritivas como nome, descrição e categoria, sendo referenciado por `TrainingExercise` dentro de um treino.

---

## Propriedades

| Propriedade | Tipo | Descrição |
|---|---|---|
| `Id` | `int` | Identificador único do exercício |
| `UserId` | `Guid` | Identificador do usuário que cadastrou o exercício |
| `Name` | `string` | Nome do exercício |
| `Description` | `string` | Descrição detalhada do exercício |
| `Category` | `string` | Categoria do exercício (ex: peito, costas, pernas) |

---

## Construtor

```csharp
public Exercise(Guid userId, string name, string description, string category)
```

Cria um novo exercício associado ao usuário informado.

---

## Métodos

#### `UpdateName(string name)`
Atualiza o nome do exercício.

!!! failure "Lança `InvalidOperationException`"
    Se `name` for `null` ou contiver apenas espaços em branco.

#### `UpdateDescription(string? description)`
Atualiza a descrição. Aceita `null`, armazenando `string.Empty` nesse caso.

#### `UpdateCategory(string category)`
Atualiza a categoria do exercício. Lança `InvalidOperationException` se `category` for `null`.

---

## Exemplo de Uso

```csharp
var exercise = new Exercise(
    userId: user.Id,
    name: "Supino Reto",
    description: "Exercício para desenvolvimento do peitoral maior.",
    category: "Peito"
);

exercise.UpdateName("Supino Reto com Barra");
exercise.UpdateCategory("Peito / Tríceps");
exercise.UpdateDescription(null); // armazena string.Empty
```

---

## Observações

- `Exercise` é uma entidade pertencente ao usuário mas **referenciada** (não contida) dentro de `TrainingExercise`.
- A categoria é uma `string` livre — não há enum ou lista restrita, o que dá flexibilidade ao usuário para organizar seus exercícios como preferir.
