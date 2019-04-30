using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifiers
{
    class Program
    {
        static void Main()
        {
            // Quantifying Operations
            List<int> ints = new List<int>() { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 6, 7, 8, 8, 4, 3 };
            string st1 = "I am a cat";

            // all method
            // checks if all of the numbers in the given collection add a certain condition. Gives true or false.
            Console.WriteLine(ints.All(i => i > 0));
            Console.WriteLine(ints.All(i => i > 2));

            // any method
            // check if any item is higher than the condition.
            Console.WriteLine(ints.Any(i => i > 5));

            // contains method
            // check if a given value is contained by the collection
            Console.WriteLine(ints.Contains(9));


            Console.WriteLine("blOOp!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
