using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Stock
    {
        public Stock(StockNameEnum name, decimal price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount; 
        }
        public StockNameEnum Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

    }
}
