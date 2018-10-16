# Entity framework in ASP.NET

## EF Core toevoegen aan je applicatie

1. In `Startup` -> `ConfigureServices`

```csharp 
public void ConfigureServices(IServiceCollection services)
{
  ...
    services.AddDbContext<PersonContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));
  ...
}
```



