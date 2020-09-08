using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetEventModel
{
    public class PriceChangedEventArgs
    {
        public readonly decimal OldPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal oldPrice, decimal newPrice)
        {
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }

    public delegate void PriceChangedHandler(object sender, PriceChangedEventArgs e);

    public class Product
    {
        public event PriceChangedHandler OnPriceChanged;
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
                if (OnPriceChanged != null)
                {
                    OnPriceChanged(this, new PriceChangedEventArgs(oldPrice, _price));
                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.Price = 400;
            product.OnPriceChanged += product_PriceChange;
            product.Price = 5000;

            Console.Read();
        }

        public static void product_PriceChange(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine("Old price:" + e.OldPrice);
            Console.WriteLine("New price:" + e.NewPrice);
        }
    }
}
