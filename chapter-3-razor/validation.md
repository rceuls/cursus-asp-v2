# Validation

* Soms zijn je gebruikers té slim. Of net niet slim genoeg.
* Zowel frontend als backend.
* Frontend is default met jQuery, maar je kan via je `ModelState` aan je errors aan.
* Het volledige voorbeeld is te vinden op [github](https://github.com/rceuls/cursus-asp-v2-examples/tree/master/Csharp-Validation)

## Hoe?

### Model

```csharp
[StringLength(60, MinimumLength = 3)]
[Required]
public string Name { get; set; }
```

In dit geval zie je dat de Naam verplicht is en 3 tot 60 karakters moet bevatten.

Deze annotations (ook wel metadata) bevinden zich allemaal in de [System.ComponentModel.DataAnnotations](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-2.1) namespace.

> Let wel op; niet alle annotations zijn voor frontend validation! De [ConcurrencyCheck](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.concurrencycheckattribute?view=netcore-2.1) of [Key](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.keyattribute?view=netcore-2.1) hebben alleen nut binnen een andere context; hierover later meer.

### View

```html
<div asp-validation-summary="All" class="text-danger"></div>

<div class="form-group">
    <label asp-for="Name" class="col-md-2 control-label"></label>
    <div class="col-md-10">
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
</div>
```

Je gebruikt hier de volgende element
* Een `asp-for` op een `input`. Dit noemt men een [Input Tag Helper](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-2.1#the-input-tag-helper).
* Een `asp-validation-for` voor één element dat je kan binden aan een property op je model (in dit geval `Name`). Dit noemen we een [Validation Message Tag Helper](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-2.1#the-validation-message-tag-helper).
* Een `asp-validation-summary` waarin een overzicht komt van alle fouten binnen het model. Dit noemt men een [Validation Summary Tag Helper](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-2.1#the-validation-summary-tag-helper).


### Controller

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Kitten kitten)
{
  if (ModelState.IsValid)
  {
    _context.Kittens.Add(kitten);
    _context.SaveChanges();
    return RedirectToAction("Index");
  }
  return View(kitten);
}
```

* De [ValidateAntiForgeryToken](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.validateantiforgerytokenattribute?view=aspnet-mvc-5.2) werkt samen met de [Form Tag Helper](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-2.1#the-form-tag-helper) om [XSRF/CRF attacks](https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-2.1) tegen te gaan.
* Bind
* `ModelState` bevat de staat van uw bindings; of ze valid zijn en wat eventueel de fouten zijn.
