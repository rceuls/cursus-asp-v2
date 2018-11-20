# Migrations

## Doel
* Aanmaken database en up to date houden met het eigenlijke model.
* Via de .NET cli tool `dotnet ef migrations`.
* Genereert code op basis van de `DbContext` die geregistreerd is via je `Startup`.
* Zie ook het voorbeeldproject op [github](https://github.com/rceuls/cursus-asp-v2-examples/tree/master/EntityFrameworkMigrations) en de documentatie op [msdn](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/)