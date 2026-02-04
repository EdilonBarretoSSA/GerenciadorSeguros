# GerenciadorSeguros

API responsável pelo gerenciamento de propostas e contratação de seguros.


## 🛠 Tecnologias

- .NET 9
- ASP.NET Core
- Entity Framework Core
- SQL Server

## 📋 Pré-requisitos

- .NET SDK 9.0+
- SQL Server
- Git


## ▶️ Como executar

No bash
git clone https://github.com/EdilonBarretoSSA/GerenciadorSeguros
cd gerenciador-seguros
dotnet restore
dotnet run


## 🧩 Arquitetura

Este projeto utiliza Arquitetura Hexagonal:

- Domain
- Application
- Infrastructure
- API

## ⚙️ Configurações

Edite o arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SegurosDb;Trusted_Connection=True;"
  }
}