# Basis
* Paradigma: objecten bevatten data (fields) en procedurele code (functions)
* Deze objecten kunnen hun eigen data aanpassen

## Classes
* De structuur van de data
* De beschikbare procedures
* Een soort van "blueprint".

## Objects
* Instanties van classes

## Voorbeelden
- De klasse is `Cat`, het object is `Garfield`
- De klasse is `Soda`, het object is `Cola Light`

# In C#
## Class
```cs
public class Cat 
{
    public string Name { get; set; }
    public bool IsHissing { get; set; }
}
```

## Objects
```cs
public class Program
{
    static void Main(string[] args)
    {
        var cat = new Cat();
        cat.Name = "Felix";
        cat.IsHissing = true;

        Console.WriteLine($"{cat.Name} - Hisses? {cat.IsHissing}");
    }
}
```

## Inheritance
```cs
public abstract class Animal
{
    public string Name { get; set; }
}

public class Cat : Animal
{
    public bool IsHissing { get; set; }
}

public class Dog : Animal
{
    public bool IsBarking { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var cat = new Cat();
        cat.Name = "Felix";
        cat.IsHissing = true;

        var dog = new Dog()
        {
            Name = "Rex",
            IsBarking = false
        };

        SayName(cat);
        SayName(dog);

        Console.WriteLine($"{dog.Name} is barking: {dog.IsBarking}");
        Console.WriteLine($"{cat.Name} is hissing: {cat.IsHissing}");

    }

    private static void SayName(Animal namedAnimal)
    {
        Console.WriteLine(namedAnimal.Name);
    }
}
```

## Encapsulation
```cs
public class Cat 
{
    public Cat()
    {
        IsNaughty = false;
    }
    public string Name { get; set; }
    public bool IsHissing { get; set; }
    public bool IsNaughty { get; private set; }
}

class Program
{
    static void Main(string[] args)
    {
        var cat = new Cat();
        cat.Name = "Felix";
        cat.IsHissing = true;
        // cat.IsNaughty = true; // Gaat niet, accessor is private 
        Console.WriteLine($"{cat.Name} is hissing: {cat.IsHissing}. Is naughty? {cat.IsNaughty}");
    }
}
```

Access modifiers bepalen wat er toegang heeft tot fields/functions van een bepaalde klasse.

| Access modifier    | Functie                                                       |
| ------------------ | ------------------------------------------------------------- |
| public             | Alle code kan dit aanspreken                                  |
| private            | Alleen te gebruiken binnen de klasse zelf                     |
| protected          | Alleen binnen de klasse zelf of zijn derivaten                |
| internal           | Alleen binnen de assembly waarin de klasse gedefinieerd staat |
| protected internal | Combinatie van protected en internal                          |

## Interfaces
* Een contract dat definieert welke properties/methodes een klasse dient de bevatten.
* Implementatie is klasse-afhankelijk.
* Veel gebruikt; belangrijk voor dependency injection.

```cs
public interface IHaveAName
{
    string Name { get; set; }
}

public class Cat : IHaveAName
{
    public Cat()
    {
        IsNaughty = false;
    }
    public string Name { get; set; }
    public bool IsHissing { get; set; }
    public bool IsNaughty { get; private set; }
}

public class Human : IHaveAName
{
    public string Name { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var cat = new Cat() {
            Name = "Felix"
        };
        var human = new Human() {
            Name = "Jos"
        };
        SayMyName(cat);
        SayMyName(human);
    }

    private static void SayMyName(IHaveAName named)
    {
        Console.WriteLine($"{named.Name}");
    }
}
```