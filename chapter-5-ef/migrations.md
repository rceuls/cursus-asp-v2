# Migrations

* Aanmaken database en up to date houden met het eigenlijke model in je code.
* Via de .NET cli tool `dotnet ef migrations`.
* Genereert code op basis van de `DbContext` die geregistreerd is via je `Startup`.
* Zie ook het voorbeeldproject op [github](https://github.com/rceuls/cursus-asp-v2-examples/tree/master/EntityFrameworkMigrations) en de documentatie op [msdn](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
* Je kan ook je database "seeden" met data. Gebruik hiervoor de `OnModelCreating` methode van je `Context`. Meer informatie en voorbeelden kan je [hier](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding) vinden.

## Fluent API / Column Mapping
* Je kan op twee manieren definiëren hoe je model er dient uit te zien: enerzijds met Fluent API en anderzijds Column Mapping. Beiden hebben hun voordelen.

* _Fluent_ wil zeggen dat je in je `Context` gaat aanduiden hoe de kolommen zich dienen te gedragen.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .Property(b => b.BlogId)
            .HasColumnName("blog_id");
    }
```

* _Column Mapping_ geeft aan dat je entiteiten zelf gaan bijhouden (mbhv annotations) hoe de columns gemapt zijn.

```csharp
public class Blog
{
    [Column("blog_id")]
    public int BlogId { get; set; }
    public string Url { get; set; }
}
```

Meer informatie is [hier](https://docs.microsoft.com/en-us/ef/core/modeling/relational/) te vinden.