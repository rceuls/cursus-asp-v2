# MVC 
* Model-view-controller. 
* Een architectuur om gelaagde applicaties te ontwikkelen. 
* Een architectuur, dus niet gelinked aan een bepaalde technologische implementatie.

## Model
Centraal gegeven van de component, dient om data te transporteren. Dit gaat meestal over POCO (plain old CLR objects), simpele classes binnen .NET die puur voor de data-transfert dienen met behulp van eenvoudige properties.

## View
Toont de data (van het model) op een bepaalde manier. Dit kan bijvoorbeeld gaan over json data (voor een API), een website (razor, angular), een tabel binnen excel, ... 

## Controller
Neemt de input van de gebruiker binnen (via de view) en maakt de response aan die de applicatie verwacht (om te verwerken binnen de view, maar de data geven we door door middel van models). Deze controller is ook verantwoordelijk voor validatie.

# Voordelen

* High cohesion (Je kan je functionaliteit binnen de controllers groeperen)
* Low coupling (Er zijn weinig harde dependencies tussen de verschillende lagen)
* Meerdere views/model
* Er kan onafhankelijk van elkaar gewerkt worden -- de frontend kan ontwikkeld worden door één partij terwijl de controller/models door een tweede partij onder handen genomen kan worden.