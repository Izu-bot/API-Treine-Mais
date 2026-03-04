# Profile

**Namespace:** `TreineMais.Domain.Entity`

`Profile` armazena os dados pessoais e físicos do usuário, incluindo informações como nome, gênero, data de nascimento, altura, peso e metas de treinamento.

---

## Propriedades

| Propriedade | Tipo | Descrição |
|---|---|---|
| `UserId` | `Guid` | Chave estrangeira para o `User` dono do perfil |
| `Name` | `string` | Nome do usuário |
| `Gender` | `Gender?` | Gênero (opcional) |
| `BirthDate` | `DateTime?` | Data de nascimento (opcional) |
| `Height` | `Height?` | Altura encapsulada em value object |
| `Weight` | `Weight?` | Peso encapsulado em value object |
| `Goals` | `string` | Metas de treino do usuário |
| `User` | `User` | Referência de navegação para o `User` |

---

## Construtor

```csharp
public Profile(
    Guid userId,
    string name,
    Gender? gender,
    DateTime? birthDate,
    Height? height,
    Weight? weight,
    string? goals
)
```

!!! warning "Validações"
    - `height` não pode ser `null` — lança `ArgumentNullException`
    - `weight` não pode ser `null` — lança `ArgumentNullException`
    - `goals` aceita `null`, sendo armazenado como `string.Empty`

---

## Métodos

#### `UpdateName(string name)`
Atualiza o nome do usuário.

!!! failure "Lança `InvalidOperationException`"
    Se `name` for `null` ou contiver apenas espaços em branco.

#### `UpdateHeight(Height height)`
Atualiza a altura. Lança `InvalidOperationException` se `height` for `null`.

#### `UpdateWeight(Weight weight)`
Atualiza o peso. Lança `InvalidOperationException` se `weight` for `null`.

#### `UpdateGoals(string goals)`
Atualiza as metas do usuário. Lança `InvalidOperationException` se `goals` for `null`.

---

## Exemplo de Uso

```csharp
var profile = new Profile(
    userId: user.Id,
    name: "Maria Oliveira",
    gender: Gender.Female,
    birthDate: new DateTime(1995, 6, 15),
    height: new Height(1.68m),
    weight: new Weight(62.5m),
    goals: "Ganho de massa muscular"
);

profile.UpdateName("Maria Silva");
profile.UpdateWeight(new Weight(61.0m));
profile.UpdateGoals("Definição muscular");
```

---

## Observações

- O `Profile` é criado separadamente do `User` e associado via `User.UpdateProfile(profile)`.
- `Gender` e `BirthDate` são opcionais, permitindo cadastro incremental de dados.
- `Height` e `Weight` são **value objects** que encapsulam validações de unidade e valor.
