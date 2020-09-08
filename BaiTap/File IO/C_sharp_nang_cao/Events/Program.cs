using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);
    class Product
    {
        public event PriceChangedHandler OnPriceChange;
        private decimal _price;

        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (_price == value) return;
                decimal oldPrice = _price;
                _price = value;
                if (OnPriceChange != null)
                {
                    OnPriceChange(oldPrice, _price);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.Price = 1500;
            product.OnPriceChange += product_PriceChange;
            product.Price = 3000;
            Console.Read();
        }

        private static void product_PriceChange(decimal oldPrice, decimal newPrice)
        {
            Console.WriteLine("Old price:" + oldPrice);
            Console.WriteLine("New price:" + newPrice);
        }
    }
}
