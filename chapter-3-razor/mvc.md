# Typed Pages

* Je kan een `@model <TypeName>` specifieren voor een bepaalde pagina;
* Deze pagina is dan _strongly typed_; dit wil zeggen dat deze pagina at compiletime kan gevalideerd worden en je dus niet per ongeluk niet-bestaande properties gebruikt. 
* Je krijgt ook intellisense :).

## Componenten

Je hebt hier drie aanpassingen voor nodig; het model moet aangemaakt worden, de controller aangepast zodat die geen gebruik meer maakt van de `ViewBag` en de view zodat deze ook gebruik maakt van het model.

Dit is de meest gangbare manier om MVC te implementeren binnen de ASP .NET Core stack.

### Model

Dit is een DTO (een data transfer object). Dit object mag onder geen beding logica bevatten; de enige verantwoordelijkheid van het object is data doorgeven van de controller naar de view.

Maak een nieuwe class aan in de namespace `Models`

```csharp
public class BaseModel
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
}
```

### View

Je dient hier enerzijds bovenaan aan te geven dat je met het BaseModel gaat werken op de pagina; anderzijds kan je vanaf dan ook gebruik maken van de `@Model` notatie om de properties van het model op te roepen.

```html
@model BaseModel

<div>
  <div>@Model.FirstName</div>
  <div>@Model.LastName</div>
</div>
```

Merk op dat de eerste lijn `@model` schrijft met een kleine letter en de daaropvolgende `@Model`-tags allemaal beginnen met een hoofdletter.

### Controller

De controller "vult" het model op met data en geeft het mee als een parameter aan de `return View()` call.

```csharp
public IActionResult Hello()
{
  return View(new BaseModel() { FirstName = "Raf", LastName = "Ceuls" });
}
```
