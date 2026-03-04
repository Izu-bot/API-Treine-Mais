# User

**Namespace:** `TreineMais.Domain.Entity`

`User` é a **raiz do agregado principal** da aplicação. Centraliza a identidade do usuário, suas credenciais de acesso, perfil pessoal e todas as coleções relacionadas (exercícios, treinos e rotinas).

---

## Propriedades

| Propriedade | Tipo | Descrição |
|---|---|---|
| `Id` | `Guid` | Identificador único gerado como UUID v7 |
| `Active` | `bool` | Indica se o usuário está ativo |
| `CreatedAt` | `DateTime` | Data de criação em UTC |
| `Profile` | `Profile` | Perfil pessoal do usuário |
| `Login` | `Login` | Value object com credenciais de acesso |
| `EmailConfirmed` | `bool` | Indica se o e-mail foi confirmado |
| `EmailConfirmedToken` | `string?` | Token de confirmação de e-mail (nullable) |
| `EmailConfirmationTokenExpiresAt` | `DateTime?` | Expiração do token de confirmação |
| `Exercises` | `ICollection<Exercise>` | Exercícios cadastrados pelo usuário |
| `Trainings` | `ICollection<Training>` | Treinos realizados pelo usuário |
| `Routines` | `ICollection<Routine>` | Rotinas organizadas pelo usuário |

---

## Construtor

```csharp
public User(Login login)
```

Cria um novo usuário com:

- `Id` gerado automaticamente via `Guid.CreateVersion7()`
- `Active = true`
- `EmailConfirmed = false`
- Token de confirmação de e-mail gerado automaticamente com validade de **24 horas**
- `CreatedAt` definido como `DateTime.UtcNow`

!!! warning "Validação"
    `login` não pode ser `null`. Um `ArgumentNullException` será lançado caso contrário.

---

## Métodos

### Gerenciamento de Estado

#### `ActivateUser()`
Ativa o usuário definindo `Active = true`.

#### `DeactivateUser()`
Desativa o usuário definindo `Active = false`.

---

### Confirmação de E-mail

#### `ConfirmEmail(string token)`

Confirma o e-mail do usuário validando o token informado.

| Cenário | Comportamento |
|---|---|
| E-mail já confirmado | Lança `DomainException("E-mail já confirmado.")` |
| Token inválido ou expirado | Lança `DomainException("Token inválido ou expirado.")` |
| Token válido | Define `EmailConfirmed = true` e limpa o token |

---

### Atualização de Dados

#### `UpdateProfile(Profile profile)`
Atualiza o perfil do usuário. Lança `ArgumentNullException` se `profile` for `null`.

#### `UpdateLogin(Login login)`
Atualiza as credenciais de acesso. Lança `ArgumentNullException` se `login` for `null`.

#### `UpdateProfileName(string newName)`
Delega para `Profile.UpdateName(newName)`.

#### `UpdateProfileHeight(Height newHeight)`
Delega para `Profile.UpdateHeight(newHeight)`.

#### `UpdateProfileWeight(Weight newWeight)`
Delega para `Profile.UpdateWeight(newWeight)`.

#### `UpdateProfileGoals(string newGoals)`
Delega para `Profile.UpdateGoals(newGoals)`.

---

## Exemplo de Uso

```csharp
var login = new Login("usuario@email.com", "senha_hash");
var user = new User(login);

// Confirmar e-mail
user.ConfirmEmail(user.EmailConfirmedToken!);

// Atualizar perfil
var profile = new Profile(user.Id, "João Silva", Gender.Male, ...);
user.UpdateProfile(profile);

// Desativar usuário
user.DeactivateUser();
```

---

## Observações

- O `Id` utiliza **UUID v7**, que é ordenável por tempo, o que melhora a performance em índices de banco de dados.
- O token de confirmação de e-mail é gerado como `Guid.NewGuid().ToString("N")` (32 caracteres hexadecimais sem hífens).
- Alterações de perfil são delegadas ao próprio agregado `Profile`, preservando o encapsulamento.
