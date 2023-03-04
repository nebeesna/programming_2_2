using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp2
{
    internal class Journal : Edition
    {

        public Article[] articles { get; set; }
        public double prestige_rate { get; set; }
        private const int price = 75;
        public Journal(string isbn, string title, int yearOfPublishing, Article[] articles, double prestige_rate) : base(isbn, title, yearOfPublishing)
        {
            this.articles = articles; 
            this.prestige_rate = prestige_rate;
        }
        public override double Payment()
        {
            if(prestige_rate < 1 || prestige_rate > 5)
            {
                throw new RateExeption("rate must be in [1,5]!");
            }
            else
            {
                return (price * prestige_rate) / (DateTime.Now.Year - yearOfPublishing + 1);
            }
        }
    }
}
