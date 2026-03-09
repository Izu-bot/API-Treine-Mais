# TreineMais API — Documentação v1.0.0

Base URL: `http://localhost:5297`

---

## Sumário

- [Autenticação](#autenticação)
    - [Registrar Usuário](#post-authregister)
    - [Confirmar E-mail](#get-authconfirm-email)
    - [Login](#post-authlogin)
    - [Refresh Token](#post-authrefresh)
- [Schemas](#schemas)
    - [UserRequest](#userrequest)
    - [ProfileRequest](#profilerequest)
    - [AuthRequest](#authrequest)

---

## Autenticação

Todos os endpoints de autenticação estão sob o prefixo `/auth`.

---

### POST /auth/register

Registra um novo usuário na plataforma.

**Request Body** — `application/json`

| Campo      | Tipo            | Obrigatório | Descrição                        |
|------------|-----------------|-------------|----------------------------------|
| `email`    | `string`        | ✅           | E-mail do usuário                |
| `password` | `string`        | ✅           | Senha do usuário                 |
| `profile`  | `ProfileRequest`| ✅           | Dados do perfil do usuário       |

**Exemplo de Requisição**

```json
{
  "email": "usuario@email.com",
  "password": "SenhaSegura123!",
  "profile": {
    "name": "João Silva",
    "gender": "M",
    "birthDate": "1995-06-15T00:00:00Z",
    "height": 1.75,
    "weight": 75.0,
    "goals": "Ganho de massa muscular"
  }
}
```

**Respostas**

| Status | Descrição |
|--------|-----------|
| `200`  | Usuário registrado com sucesso |

---

### GET /auth/confirm-email

Confirma o e-mail do usuário a partir de um token enviado por e-mail.

**Query Parameters**

| Parâmetro | Tipo     | Obrigatório | Descrição                        |
|-----------|----------|-------------|----------------------------------|
| `token`   | `string` | ✅           | Token de confirmação de e-mail   |

**Exemplo de Requisição**

```
GET /auth/confirm-email?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

**Respostas**

| Status | Descrição |
|--------|-----------|
| `200`  | E-mail confirmado com sucesso |

---

### POST /auth/login

Autentica o usuário e retorna um token de acesso.

**Request Body** — `application/json`

| Campo      | Tipo     | Obrigatório | Descrição             |
|------------|----------|-------------|-----------------------|
| `email`    | `string` | ✅           | E-mail do usuário     |
| `password` | `string` | ✅           | Senha do usuário      |

**Exemplo de Requisição**

```json
{
  "email": "usuario@email.com",
  "password": "SenhaSegura123!"
}
```

**Respostas**

| Status | Descrição |
|--------|-----------|
| `200`  | Login realizado com sucesso, token retornado |

---

### POST /auth/refresh

Renova o token de acesso utilizando o refresh token.

> Nenhum corpo de requisição é necessário. O refresh token deve ser enviado via cookie ou header, conforme configuração do servidor.

**Respostas**

| Status | Descrição |
|--------|-----------|
| `200`  | Token renovado com sucesso |

---

## Schemas

### UserRequest

Objeto utilizado no registro de um novo usuário.

| Campo      | Tipo            | Obrigatório | Descrição                  |
|------------|-----------------|-------------|----------------------------|
| `email`    | `string`        | ✅           | E-mail do usuário          |
| `password` | `string`        | ✅           | Senha do usuário           |
| `profile`  | `ProfileRequest`| ✅           | Perfil associado ao usuário|

---

### ProfileRequest

Dados do perfil do usuário, enviados no momento do registro.

| Campo       | Tipo      | Formato       | Obrigatório | Nullable | Descrição                         |
|-------------|-----------|---------------|-------------|----------|-----------------------------------|
| `name`      | `string`  | —             | ✅           | ❌        | Nome completo do usuário          |
| `gender`    | `string`  | —             | ✅           | ❌        | Gênero (ex: `M`, `F`, `Outro`)    |
| `birthDate` | `string`  | `date-time`   | ✅           | ❌        | Data de nascimento (ISO 8601)     |
| `height`    | `number`  | `float`       | ✅           | ❌        | Altura em metros (ex: `1.75`)     |
| `weight`    | `number`  | `float`       | ✅           | ❌        | Peso em kg (ex: `75.0`)           |
| `goals`     | `string`  | —             | ✅           | ✅        | Objetivos do usuário (opcional)   |

---

### AuthRequest

Objeto utilizado para autenticar o usuário via login.

| Campo      | Tipo     | Obrigatório | Descrição         |
|------------|----------|-------------|-------------------|
| `email`    | `string` | ✅           | E-mail do usuário |
| `password` | `string` | ✅           | Senha do usuário  |

---

*Documentação gerada a partir da especificação OpenAPI 3.0.1 — TreineMais.API v1.0.0 com Claude Code*