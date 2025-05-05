To create de Sql Server docker container, install and run docker and use in a terminal:  
docker-compose up -d

#### use Flow 01
### Flow 01
go to SQL Server management and create the database:

select name from sys.databases
go

CREATE DATABASE WebApiDotnetExampleDb;
GO

select name from sys.databases
go

## Create the table and some records from init.sql

CREATE DATABASE WebApiDotnetExampleDb;
GO

USE WebApiDotnetExampleDb;
GO

CREATE TABLE Pessoas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CPF NVARCHAR(11) NOT NULL,
    DataDeNascimento DATE NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Nome NVARCHAR(255) NOT NULL
);
GO

INSERT INTO Pessoas (CPF, DataDeNascimento, Email, Nome)
VALUES 
('12345678900', '1990-01-01', 'example1@example.com', 'John Doe'),
('98765432100', '1985-05-15', 'example2@example.com', 'Jane Doe');






### Flow 02
docker exec -it sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourSuperStrong@Passw0rd

select name from sys.databases
go

CREATE DATABASE WebApiDotnetExampleDb;
GO

No terminal na pasta do projeto:
dotnet ef migrations add InitialCreate
dotnet ef database update
