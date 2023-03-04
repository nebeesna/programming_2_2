using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekz
{
    /*Стаття характеризуються iдентифiкацiйним номером статтi, iдентифi-
кацiйним номером автора i заголовком статтi.*/
    [Serializable]
    public class Article
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public Article()
        {
            Id = 0;
            AuthorId = 0;
            Title = String.Empty;
        }
        public Article(int id, int authorId, string title)
        {
            Id = id;
            AuthorId = authorId;
            Title = title;
        }
        public override string ToString()
        {
            return $"{Id}\t{AuthorId}\t{Title}";
        }
    }
}
