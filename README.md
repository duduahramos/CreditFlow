# Escopo Geral - Projeto CreditOrchestrator

## 🧠 Objetivo do Projeto

Construir uma aplicação em C# .NET que simula uma orquestração de crédito bancário com múltiplas regras de negócio, validação desacoplada, observabilidade e persistência em PostgreSQL.

---

## 📦 Estrutura de Solução

```
CreditOrchestrator.sln
├── CreditFlow.Core/              -> Camada de domínio e aplicação (DDD)
│   ├── Domain/
│   │   ├── Entities/             -> CreditRequest.cs
│   │   ├── Interfaces/           -> ICreditRule.cs
│   │   ├── Enums/                -> CreditDecision.cs, CreditRequestStatus.cs
│   │   ├── Results/              -> RuleValidationResult.cs, CreditValidationResult.cs
│   │   └── Rules/                -> AgeValidationRule, CpfBlacklistRule, etc.
│   └── Application/              -> CreditRequestValidator.cs
│
├── CreditFlow.Infrastructure/   -> Acesso a dados e integração
│   ├── Data/                     -> CreditDbContext.cs
│   └── Repositories/            -> ICreditRequestRepository.cs, CreditRequestRepository.cs
│
├── CreditFlow.API/              -> ASP.NET Core Web API
│   ├── Controllers/             -> CreditRequestController.cs
│   ├── Models/                  -> DTOs de entrada e saída
│   └── Utils/                   -> Mapper, ExtensionMethods, etc.
```

---

## 🧾 Passo a passo para desenvolvimento

### 1. Inicialização do Projeto
- Criar solução `.sln` e projetos: Core, Infrastructure, API
- Adicionar referências cruzadas

### 2. Modelagem do Domínio (Core)
- Criar entidade `CreditRequest`
- Criar enum `CreditDecision`, `CreditRequestStatus`
- Criar `RuleValidationResult` e `CreditValidationResult`
- Criar interface `ICreditRule`
- Implementar regras de crédito: idade, score, blacklist, renda, histórico

### 3. Camada de Aplicação
- Criar `CreditRequestValidator` para aplicar todas as regras injetadas

### 4. DTOs e Mappers (API)
- Criar `CreditRequestDto`
- Criar `CreditResultDto` (opcional)
- Criar extensão `ToEntity()`

### 5. Controller HTTP
- Criar `CreditRequestController` com `POST`
- Validar DTO -> Aplicar regras -> Retornar resultado

### 6. Persistência com PostgreSQL
- Criar `CreditDbContext`
- Criar `ICreditRequestRepository` e `CreditRequestRepository`
- Registrar no DI e configurar ConnectionString
- Chamar `SaveAsync()` após validação no controller

### 7. Endpoint de Consulta (opcional)
- Criar `GET /credit-request/{id}`
- Retornar resultado da análise
- Usar DTO de saída

### 8. Extensões Futuras
- Adicionar OpenTelemetry (trace, logs, métricas)
- Enviar evento para fila SQS
- Criar dashboard com Grafana

---

## 🧩 Tecnologias e Práticas
- C# .NET 7/8
- ASP.NET Core Web API
- PostgreSQL com EF Core
- Injeção de Dependência (DI)
- Princípios SOLID e DDD
- Testes unitários (xUnit)
- Observabilidade com OpenTelemetry (futuro)
- AWS SQS (futuro)