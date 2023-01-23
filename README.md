# sample-application
## Description
#### .NET 6 sample application using repository pattern, Dapper micro ORM for database connection and EF Core for migrations.
#

## Migrations
#### To add a new migration use: 
##### .NET Core CLI
```csharp 
dotnet ef migrations add NewMigration --project Migrations
```
##### Visual Studio - Package Manager
```csharp 
Add-Migration NewMigration -Project Migrations
```

#### To update the database use:
##### .NET Core CLI
```csharp 
dotnet ef database update --startup-project sample-application --project Migrations
```

##### Visual Studio - Package Manager
```csharp 
Update-Database -Project Migrations 
```
