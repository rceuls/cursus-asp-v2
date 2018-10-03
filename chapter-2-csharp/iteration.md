```cs
using System;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("foreach loop #1");
            var items = new[] { 1, 2, 3 };
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("for loop #1");
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"{i} {items[i]}");
            }

            Console.WriteLine("do/while loop #1");
            var cnt = 0;
            do
            {
                Console.WriteLine($"{cnt} {items[cnt]}");
                cnt++;
            } while (cnt < items.Length);

            Console.WriteLine("while loop #1");

            var cnt1 = 0;
            while (cnt1 < items.Length)
            {
                Console.WriteLine($"{cnt1} {items[cnt1]}");
                cnt1++;
            } 

            Console.WriteLine("do/while loop #2");
            var cnt2 = 100;
            do
            {
                //will crash with index out of range
                //Console.WriteLine($"{cnt2} {items[cnt2]}");
                cnt++;
            } while (cnt2 < items.Length);

            Console.WriteLine("while loop #2");
            var cnt3 = 100;
            while (cnt2 < items.Length)
            {
                Console.WriteLine($"{cnt3} {items[cnt3]}");
                cnt++;
            } 

        }
    }
}
```