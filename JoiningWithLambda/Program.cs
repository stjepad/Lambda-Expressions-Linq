using System;
using System.Collections.Generic;
using System.Linq;

namespace JoiningWithLambda
{
    class Program
    {
        static void Main()
        {
            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "Scientists District", Age = 40 },
                new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Jaime", District = "Developers District", Age = 35 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
            };
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", District = "Fantasy District", Age = 22 },
                new Supplier() { Name = "Charles", District = "Developers District", Age = 40 },
                new Supplier() { Name = "Hailee", District = "Scientists District", Age = 35 },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30 }
            };
            //--------------------------------------------------------------------------------
            // Inner Join
            var innerJoin = suppliers.Join(buyers, s => s.District, b => b.District,
                (s, b) => new
                {
                    SupplierName = s.Name,
                    BuyerName = b.Name,
                    District = s.District
                });

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"District: {item.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");
            }
            SeparatingLine();
            //--------------------------------------------------------------------------------
            // Composite Join
            var compositeJoin = suppliers.Join(buyers,
                s => new { s.District, s.Age },
                b => new { b.District, b.Age },
                (s, b) => new
                {
                    SupplierName = s.Name,
                    BuyerName = b.Name,
                    District = s.District,
                    Age = s.Age
                });

            foreach (var item in compositeJoin)
            {
                Console.WriteLine($"Supplier : {item.SupplierName}, Buyer : {item.BuyerName}, District: {item.District}, Age : {item.Age}");
            }

            SeparatingLine();
            //--------------------------------------------------------------------------------
            // group Join
            var groupJoin = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
                (s, buyersGroup) => new
                {
                    s.Name,
                    s.District,
                    Buyers = buyersGroup
                });

            foreach (var supplier in groupJoin)
            {
                Console.WriteLine($"Supplier: {supplier.Name}, District: {supplier.District}");

                foreach (var buyer in supplier.Buyers)
                {
                    Console.WriteLine($" {buyer.Name}");
                }
            }
            SeparatingLine();
            //--------------------------------------------------------------------------------
            // left outer join 

            var leftOuterJoinAnon = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
                (s, buyersGroup) => new
                {
                    s.Name,
                    s.District,
                    Buyers = buyersGroup
                })
                .SelectMany(s => s.Buyers.DefaultIfEmpty(),
                (s, b) => new
                {
                    s.Name,
                    s.District,
                    BuyersName = b?.Name ?? "No Name",
                    BuyersFistrict = b?.District ?? "No District"
                });

            foreach (var item in leftOuterJoinAnon)
            {
                Console.WriteLine(item.District);
                Console.WriteLine($"{item.Name} - {item.BuyersName}");
            }
            SeparatingLine();
            //--------------------------------------------------------------------------------
            // left outer join shorter

            var leftOuterJoinType = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
                (s, buyersGroup) => new
                {
                    s.Name,
                    s.District,
                    Buyers = buyersGroup.DefaultIfEmpty(new Buyer()
                    {
                        Name = "No Name",
                        District = "No District"

                    })
                });

            foreach (var supplier in leftOuterJoinType)
            {
                Console.WriteLine($"{supplier.Name}, {supplier.District}");
                foreach (var buyer in supplier.Buyers)
                {
                    Console.WriteLine($" {buyer.Name}");
                }
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

    internal class Supplier
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }

    internal class Buyer
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }

}