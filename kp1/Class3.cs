using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp1
{
    interface IProduct
    {
        double TotalPrice(double count);   
    }
    class PieceProduct : IProduct
    {
        private string title;
        private double priceForItem;
        public string Title { get; set; }
        public double PriceForItem { get; set; }

        public double TotalPrice(double count)
        {
            return count * priceForItem;
        }
    }
    class WeightProduct : IProduct
    {
        private string title;
        private double priceForKg;
        public string Title { get; set; }
        public double PriceForKg { get; set; }

        public double TotalPrice(double count)
        {
            return count * priceForKg;
        }
    }
    class Gipermarket
    {

    }
    class DiscountCard
    {
        private double discount;
        private int bonus;

        public double Discount { get; set; }
        public int Bonus { get; set; }


    }
    class Service : IProduct
    {
        private string title;
        private double price;

        public double TotalPrice(double count)
        {
            return count * price;
        }
    }
    class Customer
    {
        DiscountCard card;
        public DiscountCard Card { get; set; }
        }

    }
}
