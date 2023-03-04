using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekz
{
    /*Бiблiографiчнi данi статтi задано у форматi < iдентифiкацiйний номе-
ром статтi, рiк i номер випуску >*/
    [Serializable]
    public class ArticleData
    {
        public int ArticleId { get; set; }
        public int Year { get; set; }
        public int RealaseNumber { get; set; }
        public ArticleData()
        {
            ArticleId = 0;
            Year = 0;
            RealaseNumber = 0;
        }
        public ArticleData(int articleId, int year, int realaseNumber)
        {
            ArticleId = articleId;
            Year = year;
            RealaseNumber = realaseNumber;
        }
        public override string ToString()
        {
            return $"{ArticleId}\t{Year}\t{RealaseNumber}";
        }
    }
}
