using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolStuffsInCSharp
{
    class Program
    {
        static void Main()
        {
            // repeat method
            var manyNumbers = Enumerable.Repeat(5, 50);
            Console.WriteLine();

            // Range method
            var numbers = Enumerable.Range(1, 100);
            Console.WriteLine();

            //  Generate odd numbers

            var oddNumbers = Enumerable.Range(1, 10).Where(n => n % 2 == 1);
            Console.WriteLine();

            // Square numbers
            var squared = Enumerable.Range(1, 10).Select(n => n * n);
            Console.WriteLine();

            // random
            Random rng = new Random();
            var randoms = Enumerable.Range(1, 10).Select(_ => rng.Next(1, 100));
            Console.WriteLine();


            SeparatingLine();
            Console.WriteLine("blOOp!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }
}
