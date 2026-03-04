# TreineMais

Bem-vindo à documentação oficial do **TreineMais**, uma aplicação de gerenciamento de treinos e rotinas de exercícios físicos.

## Sobre o Projeto

O TreineMais é estruturado seguindo os princípios do **Domain-Driven Design (DDD)**, com separação clara entre as camadas de domínio, aplicação e infraestrutura.

## Estrutura do Domínio

O domínio é composto pelas seguintes entidades principais:

| Entidade | Descrição |
|---|---|
| [`User`](domain/entities/user.md) | Usuário da aplicação, raiz do agregado principal |
| [`Profile`](domain/entities/profile.md) | Dados pessoais e físicos do usuário |
| [`Exercise`](domain/entities/exercise.md) | Exercício cadastrado pelo usuário |
| [`Training`](domain/entities/training.md) | Sessão de treino contendo exercícios |
| [`Routine`](domain/entities/routine.md) | Rotina composta por múltiplos treinos |

## Navegação

- 📖 **[Visão Geral do Domínio](domain/overview.md)** — Diagrama e relacionamentos entre entidades
- 🧩 **[Entidades](domain/entities/user.md)** — Documentação detalhada de cada entidade
