# Customer API

Esta é uma API de cadastro de clientes, desenvolvida com **ASP.NET Core** e **Entity Framework Core** usando um banco de dados em memória. A aplicação segue os princípios de **Domain-Driven Design (DDD)** e oferece operações CRUD (Criar, Ler, Atualizar, Excluir) para gerenciar clientes e seus respectivos endereços.

## Requisitos

- **.NET 6** ou superior
- **Visual Studio** ou **VS Code** (com a extensão C#)
- **SQL Server** (caso opte por usar um banco real, mas a versão atual usa o In-Memory Database)

## Funcionalidades

A API expõe os seguintes endpoints para interagir com os dados de clientes:

### Endpoints:

- **GET /clientes**: Lista todos os clientes.
- **GET /clientes/{id}**: Obtém um cliente específico pelo ID.
- **POST /clientes**: Cria um novo cliente.
- **PUT /clientes/{id}**: Atualiza um cliente existente.
- **DELETE /clientes/{id}**: Remove um cliente.

### Exemplo de Payload para Criação de Cliente

```json
{
  "Nome": "João Silva",
  "Email": "joao.silva@email.com",
  "Telefone": "11999999999",
  "Endereco": {
    "Rua": "Rua Exemplo",
    "Numero": "123",
    "Cidade": "São Paulo",
    "Estado": "SP",
    "CEP": "01010-010"
  }
}
```

# Como rodar a aplicação

## 1. Clonar o repositório
Clone este repositório para sua máquina local usando o seguinte comando (ou via GitHub Desktop etc):

```bash
git clone https://github.com/seu-usuario/nome-do-repositorio.git
```

## 2. Restaurar dependências
Navegue até a pasta do projeto e execute o seguinte comando para restaurar as dependências do .NET:
- Se estiver usando o Visual Studio, você pode usar o clique direito na solução > Restaurar pacotes do NuGet.
```bash
dotnet restore
```

## 3. Executar a aplicação
Para rodar o projeto localmente, execute o seguinte comando:

```bash
dotnet run
```
- A API deve estar disponível (por padrão) em http://localhost:7184.

## 4. Testar a API
Você pode usar ferramentas como **Postman**, **Insomnia** ou até mesmo o **Swagger** integrado para testar os endpoints da API. O Swagger deve estar disponível (por padrão) em http://localhost:7184/swagger.
- Lembre-se de passar a versão da API no cabeçalho x-api-version.


### Exemplo de Requisição (POST):
Endpoint: POST http://localhost:5000/api/v1/clientes

Cabeçalho: x-api-version: 1.0

Corpo: O JSON que define os dados do cliente.


## Configuração de Versionamento de API
A API está versionada. Para especificar qual versão da API você deseja acessar, inclua a versão desejada no cabeçalho x-api-version ou na URL.

### Exemplo
```bash
GET http://localhost:7184/api/v1/clientes
```

## Configuração de Logs
Os logs são gerados durante a execução da API para monitoramento. Eles podem ser visualizados no console.

## Testes
Os testes unitários foram implementados usando xUnit. Para rodar os testes, execute o seguinte comando:

```bash
dotnet test
```

## Tecnologias Usadas
- ASP.NET Core (Web API)

- Entity Framework Core (In-Memory Database)

- AutoMapper (para mapeamento entre DTOs e entidades)

- xUnit (Testes unitários)

- Swagger (Documentação da API)