using OOP_16_09_26_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_16_09_26_1.Services
{
    public class Service : IService
    {
        private List<Product> Products;
        private List<int> SumQs;
        private Random rnd;

        public Service()
        {
            Products = new List<Product>();
            SumQs = new List<int>();
            rnd = new Random();
        }

        public void Display()
        {
                Console.WriteLine($"{"Id",3}{"Name",13}{"Cost",10}{"Price",8}{"Q1",6}{"Q2",4}{"Q3",4}{"Q4",4} " +
                    $"{"TotalQ",8}{"TotalR",12}{"Profit",12}");

            foreach (var p in Products) 
            {
                Console.WriteLine($"{p.Id,2}{p.Name,15}{p.Cost,7}{p.Price,8}{p.Q1,6}{p.Q2,4}{p.Q3,4}{p.Q4,4} " +
                    $"{p.TotalQuantity(),8}{p.TotalRevenue(),12:N0}{p.Profit(),12:N0}"); 
            }

            var SumQ1 = Products.Sum(p => p.Q1);
            var SumQ2 = Products.Sum(p => p.Q2);
            var SumQ3 = Products.Sum(p => p.Q3);
            var SumQ4 = Products.Sum(p => p.Q4);
            var SumTotalQ = Products.Sum(p => p.TotalQuantity());
            var SumTotalR = Products.Sum(p => p.TotalRevenue());
            var SumProfit = Products.Sum(p => p.Profit());

            SumQs.Add(SumQ1);
            SumQs.Add(SumQ2);
            SumQs.Add(SumQ3);
            SumQs.Add(SumQ4);

            Console.WriteLine($"{SumQ1,40}{SumQ2,4}{SumQ3,4}{SumQ4,4} " +
                    $"{SumTotalQ,8}{SumTotalR,12:N0}{SumProfit,12:N0}");
        }

        public void MockData(int n = 10)
        {
            for (int i = 0; i < n; i++) 
            {
                var p = new Product()
                {
                    Id = "P00" + i,
                    Name = "Product " + i,
                    Cost = rnd.Next(100, 501),
                    Price = rnd.Next(300, 1001),
                    Q1 = rnd.Next(10, 31),
                    Q2 = rnd.Next(10, 31),
                    Q3 = rnd.Next(10, 31),
                    Q4 = rnd.Next(10, 31),
                };
                Products.Add(p);
            }
        }

        public void Summary() 
        {
            var p = Products.OrderByDescending(p => p.TotalQuantity()).First();
            var pF = Products.OrderByDescending(p => p.Profit()).First();

            var bestQ = SumQs.Max();
            var index = SumQs.IndexOf(bestQ);

            var sumRev = Products.Sum(p => p.TotalRevenue());
            var sumProfit = Products.Sum(p => p.Profit());
            var avgProfit = Products.Average(p => p.Profit());

            Console.WriteLine($"{p.Name } : {p.TotalQuantity()}");
            Console.WriteLine($"{pF.Name} : {pF.Profit():N0}");
            Console.WriteLine($"Q{index + 1 } : {bestQ}");

            Console.WriteLine(sumRev);
            Console.WriteLine(sumProfit);
            Console.WriteLine(avgProfit);   
        }
    }
}
