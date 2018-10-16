# Entity Framework

* Dient als een ORM (object-relational-mapper).
* Zorgt er voor dat je geen SQL dien te schrijven.
* DataAccess verloopt via een model (niet te verwarren met de 'M' in 'MVC').

## Model
* Een model bestaat uit classes voor entiteiten en een datacontext.
  * `Entiteiten` zijn 1:1 mappings met je database tables.
  * `DataContext` is de eigenlijke connectie met je database.

Hieronder kan je een simplistisch voorbeeld van een DataContext (`BloggingContext`) en een paar enteiten (`Blog` en `Post`).

```csharp
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Intro
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("my-connection-string");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public List<Post> Posts { get; set; }
        public string Name { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
```

## Data manipuleren

* Data kan gemanipuleerd worden via LINQ.
  * Opslaan/wijzigen/deleten van een blog kan door een item toe te voegen aan de `Blogs` collectie van de `BloggingContext`. Meer info kan je [hier](https://docs.microsoft.com/en-us/ef/core/saving/) terugvinden.
* Data kan opgevraagd worden via LINQ.
  * Je kan items opvragen via `FindAll`, `FirstOrDefault`, ... . Je kan ook `.Where()` gebruiken om de where clause te manipuleren om zo een subset van de data op te vragen. Meer info kan je [hier](https://docs.microsoft.com/en-us/ef/core/querying/) terugvinden.

## Connectionstring

* Een `connectionstring` is een string (duh) waarin de verbindingsinformatie van je database staat.
* Het formaat van de connectionstring verschilt per database, je kan de meeste [hier](https://www.connectionstrings.com/) terugvinden.
* Eén db-context heeft binnen de applicatie één connectionstring; dit wil zeggen dat elke DataContext slechts naar één database gaat.
* Meer info over hoe je binnen ASP.NET core je connectionstring kan zetten kun je terugvinden via [deze link](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings#aspnet-core).

## `InMemory` databases

* Een `InMemory` database is een database in het geheugen.
* Standaard meegeleverd met de `Entity Framework Core` nuget package.
* Dient om een database te simuleren maar is géén database. Niet zo slim om in productie te gebruiken dus, of om database specifieke dingen te testen. 
* Superhandig om snel een proof of concept uit te werken.
* Meer info [hier](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory).

## Installatie

* Voer het volgende uit in het mapje van waar je `*.csproj` staat: `dotnet add package Microsoft.EntityFrameworkCore.InMemory`.
    * Dit installeert uiteraard alleen maar de `InMemory` database; als je een echte relationele database wenst te verbinden moet je de provider nog installeren. Raadpleeg daarvoor de documentatie van je database provider.
