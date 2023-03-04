using System;
using System.Text;
/*
Написати для класу System.String extension method ContainsPunctuationSymbols(), який
визначає чи стрічка містить знаки пунктуації (крапка, кома і т.д.) в своєму записі.
Вводимо з консолі стрічку-речення, де слова розділені пробілами. Порахувати кількість
слів, що містять знаки пунктуації. Сформувати і вивести на консоль нове речення,
видаливши всі слова, що містять знаки пунктуації.
 */
namespace kp1
{
    class Program
    {

        static void task1(){
            Console.WriteLine("Enter a string: ");
            string str = Console.ReadLine();
            string[] words = str.Split(' ');
            StringBuilder buildResult = new StringBuilder();
            foreach (var word in words)
            {
                if (!word.ContainsPunctuationSymbols())
                {
                    buildResult.Append(word + " ");
                }
            }
            String result = buildResult.ToString();
            Console.WriteLine(result);
        }

        static void task2()
        {
            /*Дано масив книг Book(title, author, year). Вводимо книгу з консолі, вивести чи таку книгу
            знайдено в масиві, перевантаживши для цього оператор == та метод Equals(). Для полів
            класу передбачити відповідні проперті. На базі цього масиву книг сформувати і вивести
            на консоль новий масив книг, які були опубліковані після певного року (рік вводиться з
            консолі).*/
            Book[] books = new Book[5];
            books[0] = new Book { Title = "aaaaaa", Year = 2001, Author = "Author1" };
            books[1] = new Book { Title = "bbbbbb", Year = 1999, Author = "Author2" };
            books[2] = new Book { Title = "cccccc", Year = 1876, Author = "Author3" };
            books[3] = new Book { Title = "dddddd", Year = 2021, Author = "Author4" };
            books[4] = new Book { Title = "eeeeee", Year = 1567, Author = "Author5" };

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            Book otherBook = new Book();
            Console.WriteLine("\nEnter a data of new book:");
            Console.Write("Enter title: ");
            otherBook.Title = Console.ReadLine();
            Console.Write("Enter year: ");
            otherBook.Year = int.Parse(Console.ReadLine());
            Console.Write("Enter author: ");
            otherBook.Author = Console.ReadLine();

            bool isInArray = false;
            foreach (var book in books)
            {
                if (book == otherBook)
                {
                    isInArray = true;
                }
            }
            if (isInArray)
            {
                Console.WriteLine("new book is in book array!");
            }
            else
            {
                Console.WriteLine("new book is not in book array!");
            }
            int year;
            Console.WriteLine("\nEnter a year: ");
            year = int.Parse(Console.ReadLine());
            int count = 0;
            foreach (var book in books)
            {
                if(book.Year > year)
                {
                    count++;
                }
            }
            Book[] newBooks = new Book[count];
            int i = 0;
            foreach (var book in books)
            {
                if (book.Year > year)
                {
                    newBooks[i] = book;
                    i++;
                }
            }
            Console.WriteLine("\nBooks published after " + year + " year");
            foreach (var book in newBooks)
            {
                Console.WriteLine(book);
            }

        }

        static void task3()
        {
            /*Будівельний гіпермаркет продає товари та надає послуги (наприклад, доставка
великогабаритних товарів, встановлення їх і т.д.). Товари можуть продаватися поштучно
PieceProduct (title, priceForItem) та на вагу WeightProduct (title, priceForKg) (наприклад,
цвяхи). Клієнти гіпермаркета можуть оформити собі карточку знижок, яка працює
наступним чином:
● ціна товару, що продається на вагу, зменшується на p% ( p може бути різним
для різних карточок клієнта, наприклад, один клієнт має карточку зі знижкою
5%, в той час як інший – карточку зі знижкою 10%)
● ціна товару, що продається поштучно, зменшується на p%, але при цьому ще й
на карточку цього клієнта зараховується productPrice*p% бонусів, які можуть
бути використані для оплати наступної покупки
● за бажанням (за додаткову оплату) клієнт може активувати для своєї карточки
ще й p% знижки на послуги Service (title, price) (тобто, може існувати карточка
зі знижкою 5%, але знижки не поширюються на послуги, а інша карточка зі
знижкою 5% може бути застосована як до товарів, так і до послуг)

Дано масив товарів і послуг, які хоче придбати клієнт за одну покупку і певна
конфігурація карточки знижок цього клієнта. Вивести суму, яку клієнт повинен
заплатити за ці товари та послуги, а також вивести суму накопичених бонусів за цю
покупку.
В другому випадку припустимо, що клієнт купує лише послуги Service. Посортувати
куплені клієнтом послуги за алфавітом.*/
            IProduct[] productsAndServises = new IProduct[5];
            productsAndServises[0] = new PieceProduct { Title =" ggg", PriceForItem = 15.0};
            productsAndServises[1] = new PieceProduct { Title="jjj", PriceForItem= 12};
            productsAndServises[2] = new WeigthProduct { Title = "jjjgg", PieceForKg = };
            productsAndServises[3] = new Service;
            productsAndServises[4] = new PieceProduct;
            Customer customer = new Customer();
            customer.Card.Discount = 1.0;

        }
        static void Main(string[] args)
        {
            task3();
        }
    }
}
