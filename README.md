# C# API Tutorial CRUD SQL Server

By Daniel Lim-Apo

## 📖 Project Overview
This project is a tutorial demonstrating how to build a RESTful Web API using **C#** and **ASP.NET Core 10**. It implements basic CRUD (Create, Read, Update, Delete) operations for a `Pessoa` (Person) entity, using **Entity Framework Core** to connect to a **SQL Server** database. The project is designed with a clear separation of concerns using architectural layers (Model, Infra, Application, Controllers).

## 🚀 Technologies Used
- **.NET 10 SDK**
- **ASP.NET Core Web API**
- **Entity Framework Core (EF Core 10)**
- **SQL Server** (Running via Docker)
- **Swagger** (for API documentation and testing)

## 📁 Project Structure
The project is structured into the following layers to maintain clear responsibilities:
- `Model/`: Contains the domain entity class (`Pessoa.cs`).
- `Infra/Data/`: Contains data access logic, including the `ApplicationDbContext` and `PessoaRepository.cs`.
- `Application/`: Contains the business logic and services (`PessoaApplication.cs`).
- `Controllers/`: Contains the RESTful API endpoints (`PessoaController.cs`).

## 🛠️ Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) installed on your machine.
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) installed for running the SQL Server container.
- A preferred IDE such as Visual Studio, VS Code, or JetBrains Rider.

## ⚙️ Setup and Installation

### 1. Start the SQL Server Database
You can spin up a local SQL Server instance using Docker Compose. Open your terminal in the `WebApiDotnetExample` directory and run:

```powershell
docker-compose up -d
```
This command downloads the SQL Server image and runs it with the password `YourSuperStrong@Passw0rd` mapped to port `1433`.

### 2. Database Initialization
There are two alternative flows to initialize the database schema and populate it with seed data. Choose **only one** of the flows below:

#### Flow 1: Using the provided SQL Script
This flow uses the provided `init-sql/init.sql` script to create the database, the table, and insert some records.

1. You can run this command in PowerShell to pipe the file into the sqlcmd tool inside the docker container:
   ```powershell
   Get-Content init-sql\init.sql | docker exec -i sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourSuperStrong@Passw0rd
   ```
2. *(Alternatively, you can open SQL Server Management Studio (SSMS) or Azure Data Studio, connect to `localhost,1433` with user `sa` and the password `YourSuperStrong@Passw0rd`, and execute the `init-sql/init.sql` script directly).*

#### Flow 2: Using Entity Framework Core Migrations
If you prefer an approach that relies completely on C# and Entity Framework tools:

1. Open a terminal in the `WebApiDotnetExample` project folder.
2. Install the EF tools if you don't have them yet:
   ```powershell
   dotnet tool install --global dotnet-ef
   ```
3. Create the initial migration:
   ```powershell
   dotnet ef migrations add InitialCreate
   ```
4. Apply the migration to the database:
   ```powershell
   dotnet ef database update
   ```

### 3. Running the API
After setting up the database, you can run the API from the `WebApiDotnetExample` directory using the command line:

```powershell
dotnet run
```
Once the application starts, open your browser and navigate to the root or `/swagger` route to test the endpoints interactively:
- **Swagger UI:** `http://localhost:5000/` or `https://localhost:5001/` *(Check the terminal output for the exact URL and port. Swagger is configured at the root in Development mode)*.

## 📝 Endpoints Summary
The API exposes the following endpoints for the `Pessoa` resource:
- `GET /api/Pessoa` - Retrieves all persons.
- `GET /api/Pessoa/{id}` - Retrieves a specific person by ID.
- `POST /api/Pessoa` - Creates a new person.
- `PUT /api/Pessoa/{id}` - Updates an existing person.
- `DELETE /api/Pessoa/{id}` - Deletes a person.
