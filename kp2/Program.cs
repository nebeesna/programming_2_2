using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp2
{/*Бібліотека дозволяє
брати видання Edition(isbn, title, yearOfPublishing)  на дім за певну оплату. 
Бібліотека має 2 види видань - книги (в кожної книги може бути декілька авторів) 
та журнали (в кожного журналу є список статей Article(title, authorsOfTheArticle) і в кожної
статті також може бути декілька авторів). Для позначення автора книги/статті
достатньо об’єкта типу String.

Оплата за позичання
книги клієнтом бібліотеки обчислюється за формулою:

ставка_1 /
(currentYear - yearOfPublishing + 1).

Оплата за позичання
журналу клієнтом бібліотеки обчислюється за формулою:

ставка_2 *
коефіцієнт_престижності_журналу / (currentYear - yearOfPublishing + 1),

де коефіцієнт_престижності_журналу повинен бути більшим (або рівним) за 1 і
меншим (або рівним) за 5. Тут “ставка_1” та “ставка_2” - це певні константи.

1)    
Клієнт бібліотеки вибрав собі
список книг та журналів, які він хоче позичити на дім. Порахувати, яку суму він
повинен заплатити за це. Можливі випадки, що для деяких журналів бібліотека ще
не встигла проставити коефіцієнт престижності або він проставлений, але не
валідний (більший за 5 чи менший за 1). Для обробки таких випадків передбачити
кастомний exception і здійснити обробку таких винятків таким чином, щоб такі
журнали просто ігнорувалися при спробі взяти їх на дім, а на консоль виводилося
щось таке:”The journal (isbn, title) can`t be borrowed because it has invalid
prestige coefficient = 0”.

2)    
Дано список книг та журналів, які
є в бібліотеці. Для кожного автора вивести список назв книг та статей серед
наявних в бібліотеці, які він написав.

3)    
Дано список книг та журналів, які
є в бібліотеці. Клієнт може позичити книгу, тільки якщо її на даний момент не
позичив хтось інший. В списку книг та журналів є як і видання, які наразі
наявні фізично в бібліотеці, так і такі, які наразі хтось вже позичив. Кожен
раз, коли клієнт позичає видання, бібліотека записує лог(на коонсоль) в свою базу даних
такого виду: “Client {surname} has borrowed the Edition(isbn, title) on
{current_date}”. Нехай клієнт хоче позичити певну підмножину видань. За допомогою
Events просимулювати запис логів про позичання видань цим клієнтом в базу
даних.*/

    
    internal class Program
    {
        public delegate double CalculatePayment(List<Edition> l);
        public delegate void LogBorrowing(Client f, List<Edition> l);
        public static event CalculatePayment GetPayment;
        public static event LogBorrowing LogToConsole;
        static void Main(string[] args)
        {
            //task1();
            //task2();
            //task3();
        }
        public static void task1()
        {
            GetPayment = calcPayment;
            List<Edition> list = new List<Edition>();
            string[] a = { "Olha Kobylianska" };
            Book book1 = new Book("165983027", "Zemlya", 1943, a);
            string[] b = { "Author1", "Author2" };
            Book book2 = new Book("648283538", "Ivan SYla", 2001, b);
            string[] c = { "Author3", "Author4, Author5" };
            Book book3 = new Book("378292627", "50 tones of grey", 1987, c);
            string[] e = { "Author7" };
            string[] f = { "Author8", "Author9" };
            Article[] articles1 = new Article[] { new Article("kosmos", e), new Article("flowers", f) };
            Journal journal1 = new Journal("378292466", "Soltse", 2015, articles1, 4.5);
            string[] g = { "Author10" };
            string[] h = { "Author11", "Author12" };
            Article[] articles2 = new Article[] { new Article("Quantumn", g), new Article("Cucumber", h) };
            Journal journal2 = new Journal("378292466", "Soltse", 2021, articles2, 0.2);
            list.Add(book1);
            list.Add(book2);
            list.Add(book3);
            list.Add(journal1);
            list.Add(journal2);
            Console.WriteLine(GetPayment(list));

        }
        public static void task2()
        {
            List<Edition> list = new List<Edition>();
            string[] a = { "Olha Kobylianska" };
            Book book1 = new Book("165983027", "Zemlya", 1943, a);
            string[] b = { "Author1", "Author2" };
            Book book2 = new Book("648283538", "Ivan SYla", 2001, b);
            string[] c = { "Author1", "Author4, Author5" };
            Book book3 = new Book("378292627", "50 tones of grey", 1987, c);
            string[] e = { "Author7" };
            string[] f = { "Author8", "Author1" };
            Article[] articles1 = new Article[] { new Article("kosmos", e), new Article("flowers", f) };
            Journal journal1 = new Journal("378292466", "Soltse", 2015, articles1, 4.5);
            string[] g = { "Author7" };
            string[] h = { "Author11", "Author12" };
            Article[] articles2 = new Article[] { new Article("Quantumn", g), new Article("Cucumber", h) };
            Journal journal2 = new Journal("378292466", "Soltse", 2021, articles2, 0.2);
            string[] i = { "Author10" };
            string[] j = { "Author7", "Author12" };
            Article[] articles3 = new Article[] { new Article("Banana", i), new Article("Bobini", j) };
            Journal journal3 = new Journal("23565466", "Lanna", 2006, articles2, 4.3);
            list.Add(book1);
            list.Add(book2);
            list.Add(book3);
            list.Add(journal1);
            list.Add(journal2);
            list.Add(journal3);
            HashSet<string> authors = new HashSet<string>();
            foreach (var ed in list)
            {
                if (ed.GetType().Name = "Book")
                {

                }
                foreach (var author in ed.authors)
                {
                    authors.Add()
                }
            }
            Dictionary<string, List<string>> authorsBooks = new Dictionary<string, List<string>>();

        }
        public static void task3()
        {
            LogToConsole = log;
            List<Edition> list = new List<Edition>();
            string[] a = { "Olha Kobylianska" };
            Book book1 = new Book("165983027", "Zemlya", 1943, a);
            string[] b = { "Author1", "Author2" };
            Book book2 = new Book("648283538", "Ivan SYla", 2001, b);
            string[] c = { "Author1", "Author4, Author5" };
            Book book3 = new Book("378292627", "50 tones of grey", 1987, c);
            string[] e = { "Author7" };
            string[] f = { "Author8", "Author1" };
            Article[] articles1 = new Article[] { new Article("kosmos", e), new Article("flowers", f) };
            Journal journal1 = new Journal("378292466", "Soltse", 2015, articles1, 4.5);
            string[] g = { "Author7" };
            string[] h = { "Author11", "Author12" };
            Article[] articles2 = new Article[] { new Article("Quantumn", g), new Article("Cucumber", h) };
            Journal journal2 = new Journal("378292466", "Soltse", 2021, articles2, 0.2);
            string[] i = { "Author10" };
            string[] j = { "Author7", "Author12" };
            Article[] articles3 = new Article[] { new Article("Banana", i), new Article("Bobini", j) };
            Journal journal3 = new Journal("23565466", "Lanna", 2006, articles2, 4.3);
            list.Add(book1);
            list.Add(book2);
            list.Add(book3);
            list.Add(journal1);
            list.Add(journal2);
            list.Add(journal3);
            Client first = new Client("ivanov");
            List<Edition> l = new List<Edition>();
            l.Add(book1);  
            l.Add(book2);  
            LogToConsole(first, l);
            Client second = new Client("Kaplan");
            l.Clear();
            l.Add(journal3);
            l.Add(book3);
            LogToConsole(second, l);
        }

        public static double calcPayment(List<Edition> l)
        {
            double payment = 0;
            foreach (var item in l)
            {
                try { 
                    payment += item.Payment(); 
                }
                catch(RateExeption) 
                {
                    Console.WriteLine($"The journal ({item.isbn}, {item.title}) can`t be borrowed because it has invalid prestige coefficient");
                }
            }
            return payment;
        }
        public static void log(Client f, List<Edition> l)
        {
            foreach (var e in l)
            {
                f.Borrow(e);
                Console.WriteLine($"Client {f.lastName} has borrowed the Edition({e.isbn}, {e.title}) on { DateTime.Now} ");
            }
        }
    }
}
