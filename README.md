# Customer API

Esta � uma API de cadastro de clientes, desenvolvida com **ASP.NET Core** e **Entity Framework Core** usando um banco de dados em mem�ria. A aplica��o segue os princ�pios de **Domain-Driven Design (DDD)** e oferece opera��es CRUD (Criar, Ler, Atualizar, Excluir) para gerenciar clientes e seus respectivos endere�os.

## Requisitos

- **.NET 6** ou superior
- **Visual Studio** ou **VS Code** (com a extens�o C#)
- **SQL Server** (caso opte por usar um banco real, mas a vers�o atual usa o In-Memory Database)

## Funcionalidades

A API exp�e os seguintes endpoints para interagir com os dados de clientes:

### Endpoints:

- **GET /clientes**: Lista todos os clientes.
- **GET /clientes/{id}**: Obt�m um cliente espec�fico pelo ID.
- **POST /clientes**: Cria um novo cliente.
- **PUT /clientes/{id}**: Atualiza um cliente existente.
- **DELETE /clientes/{id}**: Remove um cliente.

### Exemplo de Payload para Cria��o de Cliente

```json
{
  "Nome": "Jo�o Silva",
  "Email": "joao.silva@email.com",
  "Telefone": "11999999999",
  "Endereco": {
    "Rua": "Rua Exemplo",
    "Numero": "123",
    "Cidade": "S�o Paulo",
    "Estado": "SP",
    "CEP": "01010-010"
  }
}
```

# Como rodar a aplica��o

## 1. Clonar o reposit�rio
Clone este reposit�rio para sua m�quina local usando o seguinte comando (ou via GitHub Desktop etc):

```bash
git clone https://github.com/seu-usuario/nome-do-repositorio.git
```

## 2. Restaurar depend�ncias
Navegue at� a pasta do projeto e execute o seguinte comando para restaurar as depend�ncias do .NET:
- Se estiver usando o Visual Studio, voc� pode usar o clique direito na solu��o > Restaurar pacotes do NuGet.
```bash
dotnet restore
```

## 3. Executar a aplica��o
Para rodar o projeto localmente, execute o seguinte comando:

```bash
dotnet run
```
- A API deve estar dispon�vel (por padr�o) em http://localhost:7184.

## 4. Testar a API
Voc� pode usar ferramentas como **Postman**, **Insomnia** ou at� mesmo o **Swagger** integrado para testar os endpoints da API. O Swagger deve estar dispon�vel (por padr�o) em http://localhost:7184/swagger.
- Lembre-se de passar a vers�o da API no cabe�alho x-api-version.


### Exemplo de Requisi��o (POST):
Endpoint: POST http://localhost:5000/api/v1/clientes

Cabe�alho: x-api-version: 1.0

Corpo: O JSON que define os dados do cliente.


## Configura��o de Versionamento de API
A API est� versionada. Para especificar qual vers�o da API voc� deseja acessar, inclua a vers�o desejada no cabe�alho x-api-version ou na URL.

### Exemplo
```bash
GET http://localhost:7184/api/v1/clientes
```

## Configura��o de Logs
Os logs s�o gerados durante a execu��o da API para monitoramento. Eles podem ser visualizados no console.

## Testes
Os testes unit�rios foram implementados usando xUnit. Para rodar os testes, execute o seguinte comando:

```bash
dotnet test
```

## Tecnologias Usadas
- ASP.NET Core (Web API)

- Entity Framework Core (In-Memory Database)

- AutoMapper (para mapeamento entre DTOs e entidades)

- xUnit (Testes unit�rios)

- Swagger (Documenta��o da API)