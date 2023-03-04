using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp2
{
    internal class Article
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public Article(string title, string[] authors)
        {
            this.title = title;    
            this.authors = authors;
        }
    }
}
