# Lab 8 School Management

Author: Lê Hoàng Trí (524H0199)

Two independent ASP.NET Core 10 applications demonstrate the same school management model using Razor Pages and MVC. Each has its own SQL Server database and EF Core context.

## Run migrations

The `InitialCreate` migrations are included. Install `dotnet-ef` version 8.0.11 and run from the solution directory:

```powershell
dotnet ef database update --project SchoolManagement.Razor
dotnet ef database update --project SchoolManagement.Mvc
```

Configure `ConnectionStrings:SchoolContext` in each `appsettings.json` for your SQL Server instance. The default targets SQL Server LocalDB. Run the apps with `dotnet run --project SchoolManagement.Razor` and `dotnet run --project SchoolManagement.Mvc` and open `/Students`.
