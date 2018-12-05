# Unit Testing

* Belangrijk voor je eigen mentale gezondheid want je weet dat je code blijft werken.
* Minder tijd spenderen aan functionele testing.
* Minder regressie.
* Zelf-documenterende code.

> Voor deze materie is code de beste uitleg; zie hiervoor het voorbeeldproject op [GitHub](https://github.com/rceuls/cursus-asp-v2-examples/tree/master/CsharpUnitTest).

## Best practices Algemeen

* Liever veel snelle testen dan een paar trage.
* Geisoleerd
* 'Repeatable'
* Automatisch

## Verschillende libraries

* xunit
* mstest
* nunit

Wij concentreren ons op nunit; dit is een volledig arbitraire keuze.

## Best Practices Opbouw

* Meestal intern afgesproken, maar er zijn wat sensible defaults:
    * Naam van de test bestaat uit drie delen: Naam van de methode; scenario waaronder je het test; verwachtte uitkomst.
    
    ```csharp
    public void Add_SingleKitten_DatabaseReturnsNewId() {}
    public void Add_ExistingKitten_WeGetAnError() {}
    ```
    * Intern moet je van AAA doen (_Arrange_ the objects, _Act_ on the object, _Assert_ the results)
    * Minimale tests; niet te veel testen. Liever een test extra schrijven.
    * Zo weinig mogelijk logica in de test zelf.
    * Eén Assert per test.

## Moq

* Je wilt slechts één klasse per keer testen; daarom heb je mocks nodig
* Gebruik hiervoor de `Moq` library; deze kan je toevoegen via nuget. Documentatie op [de website](https://github.com/Moq/moq4/wiki/Quickstart)

