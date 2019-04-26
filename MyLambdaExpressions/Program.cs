using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLambdaExpressions
{
    class Program
    {
        static void Main()
        {
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            List<int> numbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };
            object[] mix = { 1, "string", 'd', new List<int>() { 1, 2, 3, 4 }, new List<int>() { 5, 2, 3, 4 }, "dd", 's', "Hello Kitty", 1, 2, 3, 4, };

            SeparatingLine();

            List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior() { Height = 100 },
                new Warrior() { Height = 80 },
                new Warrior() { Height = 100 },
                new Warrior() { Height = 70 },
            };
            //----------------------------------------------
            Console.WriteLine(" The Linq way");

            var oddNumbers = from n in numbers
                             orderby n 
                             where n % 2 == 1
                             select n;

            Console.WriteLine(string.Join(", ", oddNumbers));
            SeparatingLine();
            //----------------------------------------------
            Console.WriteLine("The Lambda way");

            var oddNumbers1 = numbers.Where(n => (n % 2 == 1));

            Console.WriteLine(string.Join(", ", oddNumbers1));
            SeparatingLine();
            //----------------------------------------------
            Console.WriteLine("Select statement returns");

            var shortWarrior = warriors.Where(wh => wh.Height == 100)
                .Select(wh =>(wh.Height));

            Console.WriteLine(string.Join(", ", shortWarrior));
            SeparatingLine();
            //----------------------------------------------
            Console.WriteLine("Built in for each");

            List<int> shortWarrior1 = warriors.Where(wh => wh.Height == 100)
                      .Select(wh => (wh.Height))
                      .ToList();

            warriors.ForEach(w => Console.Write(w.Height + " "));
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
    internal class Warrior
    {
        public int Height { get; set; }
    }
}