  # Tag Helpers
Tag helpers zijn een manier om boiler-plate code te vermijden en de applicatie iets meer maintainable te maken.

```html
@model BaseModel

<div>
  <input asp-for="FirstName" />
  <div>@Model.LastName</div>
</div>
```

Merk hier het volgende op:
* Tag Helpers maken gebruik van de `asp-` prefix;
* Je moet `Model` niet expliciet typen als je het in een tag helper gebruikt.

Een ander voorbeeld genereert een simpele `<a>` tag naar de index pagina:

```html
<a asp-controller="Home" asp-action="Index">Home</a>
```

Deze syntax heeft als voorbeeld dat als je de achterliggende route aanpast je dit niet overal moet updaten; de combinatie van `controller` en `action` helper zorgt er voor dat de links at runtime gegenereerd worden en onafhankelijk zijn van de fysieke routing.

> Voor meer documentatie verwijs ik je graag door naar de [Microsoft docs site](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-2.1), waar meer concrete voorbeelden en alomvattende documentatie staat.