# Dependency Injection

* Een manier om dependencies van objecten te beheren.
* Verhoogt de maintainability; je moet geen classes aanpassen, alleen waar je de container aanmaakt die je dependencies gaat beteren.

## Implementatie in ASP.NET Core

* Komt standaard met ASP.NET Core via [IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/system.iserviceprovider?view=netcore-2.1).
* Je koppelt bestaande instanties aan bepaalde interfaces die je op hun beurt injecteert via constructor injector in andere classes.

### Voorbeeld

Het onderstaande is de interface die je gaat gebruiken binnen de context.
```csharp
public interface IMyService {
  void DoStuff();
}
```

Het onderstaande is de implementatie van bovenstaande interface.
```csharp
public class MyServiceImpl : IMyService {
  public void DoStuff() {
    // Stuff
  }
}
```

De volgende `class` maakt gebruik van de bovenstaande interface met behulp van de interface & constructor injection.
```csharp
public class MyServiceConsumer {
  // field declarations 
  public MyServiceConsumer(IMyService service) {
    _service = service;
  }

  public void DoStuffNeedsToBeDone() {
    _service.DoStuff();
  }
}
```

Dit moet je in je `Startup.cs` zetten (in de methode ); je zegt tegen de servicecontainer om de `class` te linken aan de interface zodat die geresolved kan worden.
```csharp
services.AddScoped<IMyService, MyServiceImpl>();
```

## Lifetimes
Een component heeft één van drie lifetimes

* Een **Transient** component wordt elke keer aangemaakt als je ze opvraagt;
* Een **Scoped** component wordt één keer per request aangemaakt.
* Een **Singleton** component wordt één keer aangemaakt per applicatie.

## Impliciete registraties
Sommige componenten worden onrechtstreeks geregistreerd als je bijvoorbeeld Entity Framework toevoegt; denk maar aan de Datacontext. Dit staat meestal in de documentatie van de library.