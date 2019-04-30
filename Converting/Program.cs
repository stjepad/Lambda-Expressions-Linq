using System;
using System.Collections.Generic;
using System.Linq;

namespace Converting
{
    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Buyer() { Age = 20 , ID = 1, Height = 125, Weight = 77},
                new Buyer() { Age = 25 , ID = 2, Height = 150, Weight = 88},
                new Buyer() { Age = 20 , ID = 5, Height = 100, Weight = 58},
                new Supplier() { Age = 22 },
                new Supplier() { Age = 20 }
            };

            //---------------------------------------
            //Converting inefficient
            var buyers = from p in people
                         where p is Buyer
                         let b = p as Buyer
                         where b.Age == 20
                         where b.ID < 5
                         where b.Height > 100
                         where b.Weight > 50
                         where b.Weight < 80
                         select b;

                Console.WriteLine(buyers.Count());
            SeparatingLine();
            //---------------------------------------
            //Converting efficient

            var buyers1 = from p in people
                         where p is Buyer
                         let b = p as Buyer
                         where (b.Age == 20 && b.ID < 5) && (b.Height > 100 || (b.Weight > 50 && b.Weight < 80))
                         select b;

                 Console.WriteLine(buyers1.Count());
            SeparatingLine();
            //---------------------------------------
            //Converting to array
            var toCollection = (from p in people
                                select p).ToList();

            Person[] personArray = toCollection.ToArray();
            List<Person> personList = toCollection.ToList();



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
    internal class Person
    {

    }

    internal class Buyer : Person
    {
        public int Age { get; set; }
        public int ID { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    internal class Supplier : Person
    {
        public int Age { get; set; }
    }
}