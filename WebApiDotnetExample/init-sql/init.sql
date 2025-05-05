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
