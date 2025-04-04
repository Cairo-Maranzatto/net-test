# Mapeamento Completo do Projeto

## 1. Camada de Domínio (Domain)

### 1.1 Entidades
- `Entities/Sale.cs`: Entidade principal de venda
- `Entities/SaleItem.cs`: Item de venda
- `Entities/Product.cs`: Produto
- `Entities/Customer.cs`: Cliente
- `Entities/Branch.cs`: Filial

### 1.2 Eventos
- `Events/SaleCreatedEvent.cs`: Evento de criação de venda
- `Events/SaleCancelledEvent.cs`: Evento de cancelamento de venda
- `Events/ItemCancelledEvent.cs`: Evento de cancelamento de item

### 1.3 Repositórios
- `Repositories/ISaleRepository.cs`: Interface do repositório de vendas
- `Repositories/ISaleItemRepository.cs`: Interface do repositório de itens de venda

### 1.4 Validações
- `Validation/SaleValidation.cs`: Validações de venda
- `Validation/SaleItemValidation.cs`: Validações de item de venda

### 1.5 Especificações
- `Specifications/SaleSpecification.cs`: Especificações para consultas de venda
- `Specifications/SaleItemSpecification.cs`: Especificações para consultas de item

### 1.6 Serviços
- `Services/ISaleService.cs`: Interface do serviço de venda
- `Services/SaleService.cs`: Implementação do serviço de venda

### 1.7 Exceções
- `Exceptions/SaleException.cs`: Exceções específicas de venda
- `Exceptions/SaleItemException.cs`: Exceções específicas de item

### 1.8 Enums
- `Enums/SaleStatus.cs`: Status possíveis de uma venda
- `Enums/ItemStatus.cs`: Status possíveis de um item

## 2. Camada de Aplicação (Application)

### 2.1 Vendas
- `Sales/Commands/CreateSaleCommand.cs`: Comando para criar venda
- `Sales/Commands/CancelSaleCommand.cs`: Comando para cancelar venda
- `Sales/Commands/CancelItemCommand.cs`: Comando para cancelar item
- `Sales/Queries/GetSaleQuery.cs`: Consulta para obter venda
- `Sales/Queries/ListSalesQuery.cs`: Consulta para listar vendas
- `Sales/EventHandlers/SaleEventHandler.cs`: Manipulador de eventos de venda
- `Sales/DTOs/CreateSaleRequest.cs`: DTO para criação de venda
- `Sales/DTOs/SaleResponse.cs`: DTO para resposta de venda
- `Sales/Validators/CreateSaleRequestValidator.cs`: Validador de criação de venda

### 2.2 Usuários
- `Users/Commands/CreateUserCommand.cs`: Comando para criar usuário
- `Users/Queries/GetUserQuery.cs`: Consulta para obter usuário
- `Users/DTOs/UserDTO.cs`: DTO de usuário

### 2.3 Autenticação
- `Auth/Commands/LoginCommand.cs`: Comando para login
- `Auth/DTOs/LoginRequest.cs`: DTO para requisição de login
- `Auth/DTOs/TokenResponse.cs`: DTO para resposta de token

## 3. Camada de Persistência (ORM)

### 3.1 Contexto
- `DefaultContext.cs`: Contexto do Entity Framework

### 3.2 Mapeamentos
- `Mapping/SaleMapping.cs`: Mapeamento da entidade Sale
- `Mapping/SaleItemMapping.cs`: Mapeamento da entidade SaleItem
- `Mapping/ProductMapping.cs`: Mapeamento da entidade Product
- `Mapping/CustomerMapping.cs`: Mapeamento da entidade Customer
- `Mapping/BranchMapping.cs`: Mapeamento da entidade Branch

### 3.3 Repositórios
- `Repositories/SaleRepository.cs`: Implementação do repositório de vendas
- `Repositories/SaleItemRepository.cs`: Implementação do repositório de itens

### 3.4 Migrações
- `Migrations/`: Arquivos de migração do banco de dados

## 4. Camada de API (WebApi)

### 4.1 Controladores
- `Features/Sales/SalesController.cs`: Controlador de vendas
- `Features/Users/UsersController.cs`: Controlador de usuários
- `Features/Auth/AuthController.cs`: Controlador de autenticação

### 4.2 Middleware
- `Middleware/ErrorHandlingMiddleware.cs`: Middleware de tratamento de erros
- `Middleware/AuthenticationMiddleware.cs`: Middleware de autenticação

### 4.3 Mapeamentos
- `Mappings/AutoMapperProfile.cs`: Perfil de mapeamento do AutoMapper

### 4.4 Configuração
- `Program.cs`: Configuração da aplicação
- `appsettings.json`: Configurações da aplicação
- `appsettings.Development.json`: Configurações de desenvolvimento
- `Dockerfile`: Configuração do container Docker

### 4.5 Comum
- `Common/`: Componentes compartilhados da API

## 5. Documentação

### 5.1 READMEs
- `README.md`: Documentação em inglês
- `README.pt-BR.md`: Documentação em português
- `ProjectMapping.md`: Este arquivo de mapeamento

### 5.2 Swagger
- Documentação automática da API via Swagger

## 6. Testes

### 6.1 Testes Unitários
- Testes de domínio
- Testes de aplicação
- Testes de repositório

### 6.2 Testes de Integração
- Testes de API
- Testes de banco de dados

## 7. Dependências Principais

- .NET 7.0
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- Swagger/OpenAPI
- Docker
- xUnit (testes)

## 8. Estrutura de Diretórios

```
Ambev.DeveloperEvaluation/
├── src/
│   ├── WebApi/          # Camada de API/Interface
│   ├── Application/     # Camada de Aplicação
│   ├── Domain/         # Camada de Domínio
│   ├── ORM/            # Camada de Persistência
│   ├── IoC/            # Injeção de Dependência
│   └── Common/         # Componentes Compartilhados
└── tests/              # Testes Unitários e de Integração
```

## 9. Fluxo de Dados

1. **API Layer**
   - Recebe requisições HTTP
   - Valida entrada
   - Mapeia DTOs
   - Chama Application Layer

2. **Application Layer**
   - Processa comandos/queries
   - Coordena operações
   - Publica eventos
   - Chama Domain Layer

3. **Domain Layer**
   - Contém regras de negócio
   - Valida entidades
   - Publica eventos
   - Define interfaces

4. **ORM Layer**
   - Implementa persistência
   - Mapeia entidades
   - Gerencia transações
   - Otimiza queries

## 10. Padrões e Práticas

- Clean Architecture
- Domain-Driven Design (DDD)
- Command Query Responsibility Segregation (CQRS)
- Repository Pattern
- Unit of Work
- Specification Pattern
- Event Sourcing
- SOLID Principles