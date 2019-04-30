using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupingLambda
{
    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 22, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
                new Person("John", "Jones", 7, 160, 22, Gender.Male),
                new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 23, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
            };

            //1. ----------------------------------------------
            var simpleGrouping = people.Where(p => p.Age > 20)
                .GroupBy(p => p.Gender);

            foreach (var item in simpleGrouping)
            {
                Console.WriteLine($"Gender : {item.Key}");

                foreach (var p in item)
                {
                    Console.WriteLine($"Name : {p.FirstName} {p.LastName} Age: {p.Age}");
                }
            }
            SeparatingLine();
            //2. ----------------------------------------------

            var alphabeticalGroup = people.OrderBy(p => p.FirstName)
                                        .GroupBy(p => p.FirstName[0]);

            foreach (var item in alphabeticalGroup)
            {
                Console.WriteLine($"{item.Key}");

                foreach (var p in item)
                {
                    Console.WriteLine($"  {p.FirstName}");
                }
            }
            SeparatingLine();
            //3. ----------------------------------------------

            var multiKey = people.GroupBy(p => new { p.Gender, p.Age });

            foreach (var item in multiKey)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.FirstName}");
                }
            }
            SeparatingLine();
            //4. ----------------------------------------------

            int[] arrayOfNumbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            var evenOrOddNumbers = arrayOfNumbers.OrderBy(n => n)
                .GroupBy(n => (n % 2 ==0) ? "Even" : "Odd");

            foreach (var item in evenOrOddNumbers)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var n in item)
                {
                    Console.WriteLine($"{n}");
                }
            }
            SeparatingLine();
            //5. ----------------------------------------------

            var ageGroups = people.GroupBy(p => p.Age < 20 ? "Young" : p.Age >= 20 && p.Age <= 22 ? "Adult" : "Senior");

            foreach (var item in ageGroups)
            {
                Console.WriteLine(item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($"  {p.FirstName} is {p.Age} years old");
                }
            }
            SeparatingLine();
            //6. ----------------------------------------------

            var howManyOfEachGroup = people.GroupBy(p => p.Gender)
                .Select(g => new
                {
                    Gender = g.Key,
                    NumOfPeople = g.Count()
                });

            foreach (var item in howManyOfEachGroup)
            {
                Console.WriteLine($" {item.Gender}");
                Console.WriteLine($"{item.NumOfPeople}");
            }

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
        private string firstName;
        private string lastName;
        private int id;
        private int height;
        private int age;

        private Gender gender;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public Person(string firstName, string lastName, int id, int height, int age, Gender gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.Height = height;
            this.Age = age;
            this.Gender = gender;
        }
    }

    internal enum Gender
    {
        Male,
        Female
    }
}