using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_16_09_26_1.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }

        public int TotalQuantity() => Q1 + Q2 + Q3 + Q4;
        public double TotalRevenue() => TotalQuantity() * Price;
        public double TotalCost() => TotalQuantity() * Cost;
        public double Profit() => TotalRevenue() - TotalCost();
    }
}
