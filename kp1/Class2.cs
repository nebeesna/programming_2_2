using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Дано масив книг Book(title, author, year). Вводимо книгу з консолі, вивести чи таку книгу
знайдено в масиві, перевантаживши для цього оператор == та метод Equals(). Для полів
класу передбачити відповідні проперті. На базі цього масиву книг сформувати і вивести
на консоль новий масив книг, які були опубліковані після певного року (рік вводиться з
консолі).
 */

namespace kp1
{

    class Book
    {
        private string title;
        private int year;
        private string author;

        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public Book()
        {

        }
        public override string ToString()
        {
            return $"{this.Title} {this.Year} {this.Author}";
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Book)
            {
                Book otherBook = (Book)obj;
                if (this.ToString() == otherBook.ToString())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        static public bool operator ==(Book other, Book another)
        {
            return other.Equals(another);
        }
        static public bool operator !=(Book other, Book another)
        {
            return !other.Equals(another);
        }
    }
}
