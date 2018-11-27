# Middleware & filters

Voorbeeldcode is beschikbaar via [github](https://github.com/rceuls/cursus-asp-v2-examples/tree/master/CSharp-Pline).

## Middleware

* Is een onderdeel van de zogenaamde "app pipeline".
* Dient voor elke request/response.
* Is ofwel het laatste deel van de request/response afhandeling ofwel een stuk dat deze verrijkt.
* Er zijn een hele hoop [middleware's beschikbaar](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.1#built-in-middleware) maar je kan ook zelf een middleware schrijven.
* Heeft uiteraard een [pagina met inleidende begrippen en voorbeelden](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.1)

### Voorbeeld
```csharp
public class PokeMiddleware
{
  private readonly RequestDelegate _next;

  public PokeMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    Console.WriteLine("Hello from the middleware");
    // Call the next delegate/middleware in the pipeline
    await _next(context);
  }
}

public static class PokeMiddlewareExtensions
{
  public static IApplicationBuilder UsePokeMiddleware(
          this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<PokeMiddleware>();
  }
}
```

deze kan je dan toevoegen aan je pipeline via je `Startup.cs` in je `Configure` methode. 

```csharp
app.UsePokeMiddleware();
```

## Filters
* Lijken op middleware maar worden gelinkt aan één of meerdere routes.
* Kan bijvoorbeeld dienen voor authorizatie en dergelijke.
* Heeft ook [documentatie](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.1#built-in-middleware)
* Er zijn verschillende soorten filters:
  * `AuthorizationFilter` bepalen of de gebruiker voldoende rechten heeft. Deze runnen eerst.
  * `ResourceFilter` doet acties gebaseerd op het type van de resource dat opgevraagd werd; kan handig zijn om gebruik te maken van caching mechanismen.
  * `ActionFilter` bevinden zich "rond" een bepaalde actie en worden er vlak voor/na uitgevoerd.
  * `ExceptionFilter` handelen onbehandelde exceptions af.
  * `ResultFilter` worden uitgevoerd als de actie succesvol afgerond werd.

### Voorbeeld

In `PokeActionFilter.cs`

```csharp
public class PokeActionFilter : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext context)
  {
    System.Console.WriteLine($"TEST 123 {context.Controller.GetType().Name} - {context.ActionDescriptor.DisplayName}");
  }

  public override void OnActionExecuted(ActionExecutedContext context)
  {
    System.Console.WriteLine($"TEST 456 {context.Controller.GetType().Name} - {context.ActionDescriptor.DisplayName}");
  }
}
```

In je `Controller`

```csharp
[PokeActionFilter]
public IActionResult About()
{
  ViewData["Message"] = "Your application description page.";

  return View();
}
```

Nu ga je in je output (op je console/terminal) zien dat elke keer je de about pagina opendoet, je de debug-boodschap te zien krijgt.