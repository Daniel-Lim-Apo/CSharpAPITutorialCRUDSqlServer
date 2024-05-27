To create de Sql Server docker container, install anr run docker and use:  
docker-compose up -d

docker exec -it sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourSuperStrong@Passw0rd

select name from sys.databases
go

CREATE DATABASE WebApiDotnetExampleDb;
GO

No terminal na pasta do projeto:
dotnet ef migrations add InitialCreate
dotnet ef database update
