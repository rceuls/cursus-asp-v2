```csharp
using System;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] { 1, 2, 3 };
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"{i} {items[i]}");
            }

            var cnt = 0;
            do
            {
            
                Console.WriteLine($"{cnt} {items[cnt]}");
                cnt++;
            } while (cnt < items.Length);
        }
    }
}
```