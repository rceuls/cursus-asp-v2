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

2. In je controller kan je de DataContext injecten via je constructor, bv 

```charp
private PersonContext _personContext;

public HomeController(PersonContext personContext)
{
  _personContext = personContext;
}
```

3. Voor een uitgewerkt voorbeeld kan je naar [dit voorbeeldproject](https://github.com/rceuls/cursus-asp-v2-examples/tree/master/EntityFrameworkMvc) kijken waarin een basis CRUD applicatie staat.

