# sample-application
## Description
#### .NET 6 sample application using repository pattern, Dapper micro ORM for database connection and EF Core for migrations.
#

## Migrations
### To add a new migration use: 
#### .NET Core CLI
```csharp 
dotnet ef migrations add NewMigration --startup-project sample-application --project Migrations\MigrationsPostgreSQL
```
or
```csharp 
dotnet ef migrations add NewMigration --startup-project sample-application --project Migrations\MigrationsOracle
```
#### Visual Studio - Package Manager
```csharp 
Add-Migration NewMigration -Project Migrations\MigrationsPostgreSQL
```
or
```csharp 
Add-Migration NewMigration -Project Migrations\MigrationsOracle
```

## To update the database use:
#### .NET Core CLI
```csharp 
dotnet ef database update --startup-project sample-application --project Migrations\MigrationsPostgreSQL
```
or 
```csharp 
dotnet ef database update --startup-project sample-application --project Migrations\MigrationsOracle
```

#### Visual Studio - Package Manager
To create a migration for POSTGRESQL database, use:
```csharp 
Update-Database -Project Migrations\MigrationsPostgreSQL
```

To create a migration for ORACLE database, use: 
```csharp 
Update-Database -Project Migrations\MigrationsOracle
```