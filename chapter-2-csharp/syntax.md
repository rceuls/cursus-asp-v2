# Syntax
* Code testen kan door een nieuw console-project aan te maken. 
    - `dotnet new console -n projectnaam`
    - `code projectnaam`
* Een console project is een project dat een executable maakt dat gerunned kan worden met behulp van de .NET core runtime.

## Algemene Structuur 

```cs
using System; // <1> 

namespace CSharpIntro // <2>
{
    public class Program // <3>
    {
        public static void Main(string[] args) // <4>
        {
            Console.WriteLine("Hello World!"); // <5>
        }
    }
}
```

1. De `using` block geeft aan dat er classes van een externe namespace gebruikt worden en waar je ze kan vinden.

2. De `namespace` is de namespace van de applicatie. Dit is een logische onderverdeling binnen de applicatie en wordt ook exposed naar alle code die gebruik maakt van onze code. Je bepaalt deze binnen je eigen applicatie/libraries grotendeels zelf.

3. `class` es worden later besproken, in het hoofdstuk Object Oriented Programming. 

4. Dit is een function, gegroepeerde statements binnen een herbruikbar blok. 

5. Dit is een statement. Deze gaat uitgevoerd worden in de applicatie als de functie waarin het statement staat aangeroepen wordt.

## Variabelen
```cs
using System;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = "Hello World with a variable!"; // string
            Console.WriteLine(hello);

            var number1 = 1; // integer 
            var number2 = 2.0; // double
            var number3 = 2; // integer
            Console.WriteLine(number1 / number2);
            Console.WriteLine(number1 / number3);

            var booll = true; // boolean (true of false)

            Console.WriteLine(booll);

            bool? nullable = null; // nullable
            Console.WriteLine(nullable);
            nullable = true;
            Console.WriteLine(nullable);

            // nullable = 1; // werkt niet, is een int in een nullable bool!
        }
    }
}
```
 
## Conditionals 
```cs
using System;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var check = true;
            if (check)
            {
                Console.WriteLine("Item 1");
            }
            else
            {
                Console.WriteLine("Item 2");
            }

            if (!check)
            {
                Console.WriteLine("Item 3");
            }
            else
            {
                Console.WriteLine("Item 4");
            }

            if (1 == 1 + 2)
            {
                Console.WriteLine("Item 5");
            }

            if (1 == 2 - 1)
            {
                Console.WriteLine("Item 6");
            }
        }
    }
}
```