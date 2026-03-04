# Routine

**Namespace:** `TreineMais.Domain.Entity`

`Routine` representa uma rotina de treinos do usuário — um agrupamento nomeado de sessões de `Training` que pode ser repetido ao longo do tempo.

---

## Propriedades

| Propriedade | Tipo | Descrição |
|---|---|---|
| `Id` | `int` | Identificador único da rotina |
| `UserId` | `Guid` | Identificador do usuário dono da rotina |
| `Name` | `string` | Nome da rotina (ex: "Treino ABC") |
| `Description` | `string?` | Descrição opcional da rotina |
| `Trainings` | `IReadOnlyList<Training>` | Lista imutável de treinos da rotina |

---

## Construtor

```csharp
public Routine(Guid userId, string name, string? description = null)
```

O parâmetro `description` é opcional e tem `null` como valor padrão.

---

## Métodos

#### `UpdateName(string name)`
Atualiza o nome da rotina.

!!! failure "Lança `InvalidOperationException`"
    Se `name` for `null` ou contiver apenas espaços em branco.

#### `UpdateDescription(string? description)`
Atualiza a descrição. Aceita `null` sem lançar exceção.

#### `AddTraining(Training training)`
Adiciona um treino à rotina.

!!! failure "Lança `ArgumentNullException`"
    Se `training` for `null`.

---

## Exemplo de Uso

```csharp
var routine = new Routine(
    userId: user.Id,
    name: "Treino ABC - Hipertrofia",
    description: "Rotina de 3 dias focada em hipertrofia muscular"
);

routine.AddTraining(treinoA);
routine.AddTraining(treinoB);
routine.AddTraining(treinoC);

routine.UpdateName("Treino ABC - Definição");
routine.UpdateDescription(null); // remove a descrição
```

---

## Observações

- A lista `Trainings` é exposta como `IReadOnlyList<Training>`, impedindo adições diretas sem passar pela validação de `AddTraining`.
- Não há método `RemoveTraining` — caso seja necessário, isso pode ser adicionado seguindo o mesmo padrão de `AddTraining`.
- `Routine` não replica os dados dos treinos — apenas mantém referências para instâncias de `Training`.
