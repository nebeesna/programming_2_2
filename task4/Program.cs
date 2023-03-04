using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public abstract class Good
    {
        protected string name;
        protected decimal price;
        public Good(string n, decimal p)
        {
            name = n;
            if (p > 0)
            {
                price = p;
            }         
        }
        public abstract string ShowInfo(string local);
    }
    public sealed class HouseholdAppliance : Good
    {
        private int warrantyPeriodInMonths;
        public HouseholdAppliance(string name, decimal price, int warrantyPeriodInMonths) : base(name, price)
        {
            this.warrantyPeriodInMonths = warrantyPeriodInMonths;
        }
        public override string ShowInfo(string local)
        {
            return $"{name,-10}{Program.LocalisedPrice(price, local),-10}{"-" ,-16}\t{warrantyPeriodInMonths}";
        }
    }
    public sealed class Food : Good
    {
        private DateTime expirationDate;
        public Food(string name, decimal price, DateTime expirationDate) : base(name, price)
        {
            this.expirationDate = expirationDate;
        }
        public override string ShowInfo(string local)
        {
            return $"{name,-10}{Program.LocalisedPrice(price, local),-10}{Program.LocalisedDate(expirationDate, local),-16}\t-";
        }
    }
    class Program
    {
        public static string LocalisedPrice(decimal price, string local)
        {
            if (local == "UA")
            {
                   return price.ToString().Replace('.', ',');
            }
            else if (local == "EN")
            {
                return price.ToString("n2");
            }
            else throw new ArgumentException("wrong localization!");
        }

        public static string LocalisedDate(DateTime date, string local)
        {
            if (local == "UA")
            {
                return $"{date.Day}.{date.Month}.{date.Year}";
            }
            else if (local == "EN")
            {
                return $"{date.Year}/{date.Month}/{date.Day}";
            }
            else throw new ArgumentException("wrong localization!");
        }
        static void Main(string[] args)
        {
            Good[] goods =
            {
                new Food("bread", 110.00m, new DateTime(2022, 7,19)),
                new Food("donut", 71.05m, new DateTime(2022, 7,12)),
                new Food("milk", 121.55m, new DateTime(2022, 7,11)),
                new Food("jogurt", 141.30m, new DateTime(2022, 7,22)),
                new HouseholdAppliance("blender", 2300.90m, 12),
                new HouseholdAppliance("frige", 4063.00m, 10),
                new HouseholdAppliance("printer", 2029.88m, 6),
                new HouseholdAppliance("washer", 6680.90m, 12),
            };
            Console.Write("enter localization: ");
            string local = Console.ReadLine().ToUpper();
            Console.WriteLine($"{"Name",-10}{"Price",-10}{"ExpirationDate",-16}{"warrantyPeriodInMonths",-10}");
            Console.WriteLine("---------------------------------------------------------");
            foreach (var good in goods)
            {
                Console.WriteLine(good.ShowInfo(local));
            }
        }
    }
}
