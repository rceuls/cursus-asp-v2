# Syntax
* Code testen kan door een nieuw asp.net-project aan te maken en te openen in visual studio code. 
    - `dotnet new mvc -n projectnaam`


## Disable HTTPS
* Open `Startup.cs`
* Zet lijn 51 in commentaar (`// app.UseHttpsRedirection()`).

## Nieuwe pagina maken
1. Open `Controllers\HomeController.cs`
2. Maak daar een nieuwe route aan met de volgende code:

```cs
public IActionResult Hello()
{
    return View();
}
```

3. Maak een `Hello.cshtml` pagina aan in `Views\Home`

_By convention_ is het zo dat een controller actie met een bepaalde naam 1:1 gemapt zal worden op de view met dezelfde naam.

Geef dit bestand de volgende inhoud:

```html
@{
    ViewData["Title"] = "Hello";
}

<p>Hoi</p>
``` 

4. Run de applicatie door middel van het volgende commando: `dotnet watch run` en surft naar de link die je in je output ziet (default is http://localhost:5000/). Je kan je *Hello* pagina bekijken op http://localhost:5000/home/hello

> Dotnet run zorgt er voor dat de code "gewatched" gaat worden voor veranderingen. Iets simpeler dan elke keer te moeten heropstarten.

## ViewData
Je wil natuurlijk iets dynamisch laten zien op je pagina. Maak hiervoor (voorlopig) gebruik van de `ViewData`-dictionary.

1. Pas de `Hello.cshtml`-pagina aan:

```html
<p>Hoi @ViewData["CurrentDate"]</p>
@if((bool)ViewData["MyBool"]) {
  <p>yes</p>
}
else{
  <p>no</p>
}
```

2. Pas `HomeController.cs` aan:

```cs
public IActionResult Hello()
{
  ViewData["CurrentDate"] = DateTime.Now;
  ViewData["MyBool"] = DateTime.Now.Second % 3 == 0;
  return View();
}
```

> Let op, ViewData heeft geen notie van types; alles is een object. Je dient dus te _casten_ voor je operaties doet op de waarde. 

## Control structures

Volgend voorbeeld voorbat een simpele implementatie van een `if` en een `foreach` clausule:

```html
@{
  var items = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
}

<h1>My collection contains @items.Count() elements</h1>
@items
<hr />
<ol>
@foreach(var item in items) {
  @if(item % 2 == 0) {
    <li>even @item</li>
  }
  else
  {
    <li>oneven @item</li>
  }
}
</ol>

``` 

Alle blocks die beginnen met een `@` zijn code blocks; de code geassocieerd met deze blocks worden serverside gerendered. Je kan dit vrij combineren met html tags (en inline css, en javascript, ...).

## Complexere syntax

Complexere code kan uitgevoerd worden door de C# code tussen haakjes te zetten:

```html
<p>@(DateTime.Now == new DateTime(2014, 01, 01))</p>
```

Het bovenstaande geeft de tekst 'False'. Laat men de haakjes weg krijgt men een ander resultaat:

```html
<p>@DateTime.Now == new DateTime(2014, 01, 01)</p>
```

Het bovenstaande geeft de tekst '2/10/2018 18:01:35 == new DateTime(2014, 01, 01)'

## Code Blocks

Code blocks zijn stukken code die tussen accolades staan; ze worden niet gerendered.

```html
<p>Expressions: @(DateTime.Now.AddDays(1))</p>
<p>Code Blocks: @{DateTime.Now.AddDays(1);}</p>
```

Merk op dat in het bovenstaande voorbeeld de datum van morgen staat naast expressions en bij "Code Blocks" niets.

Wil je een code block renderen dien je een variabele van daarin op te roepen bij door middel van een gewone expressie. De volgende code geeft als resultaat "3".

```html
@{
  var items = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
}

<p>@items[2]</p>
```

Of je kan tussentijds html doorgeven in je block:

```html
@{
    var named = true;
    <text>Named: @named</text>
}
```

`<text>` is een door razor-herkende tag; alles dat tussen deze tag staat in een code block zal gerendered worden op de pagina, zonder extra `span`'s, `div`'s of iets dergelijk.

## Code importeren
Je kan externe namespaces importeren door middel van het `using` keyword:

```html
@using System.IO;

@Directory.GetCurrentDirectory();
```