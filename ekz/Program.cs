using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace ekz
{
    /*Розробити типи для iнформацiйної системи наукового журналу.
Автор характеризується iдентифiкацiйним номером автора, прiзвищем i
країною проживання.

Стаття характеризуються iдентифiкацiйним номером статтi, iдентифi-
кацiйним номером автора i заголовком статтi.

Бiблiографiчнi данi статтi задано у форматi < iдентифiкацiйний номе-
ром статтi, рiк i номер випуску >

Усi данi задано окремими xml-файлами.
————————
Завдання виконати з використанням linq
————————
1. Отримати csv-файл, де (використовуючи впорядкування у спадному
порядку за роками i номерами) для кожного номера журналу подано його

змiст у форматi <прiзвище автора, назва статтi>, впорядкований за прi-
звищем у лексико-графiчному порядку.

————————
2. Отримати xml-файл, де для кожного автора ( у форматi <прiзвище,
країна > у лексико-графiчному порядку без повторень ) вказано назви усiх
його статей, цей перелiк впорядкований за роками i номерами.
————————

3. Отримати xml-файл з перелiком авторiв статей, в назвi яких зустрiча-
ється задане слово, використовуючи формат <прiзвище автора, рiк, номер

випуску>. Цей перелiк впорядкувати за прiзвищем у лексико-графiчному
порядку.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            var xmlDeserialize1 = new XmlSerializer(typeof(List<Article>));
            List<Article> articles;
            using (var reader1 = new StreamReader(@"C:\code\c#\прога\ekz\ekz\articles.xml"))
            {
                articles = (List<Article>)xmlDeserialize1.Deserialize(reader1);
            }
            var xmlDeserialize2 = new XmlSerializer(typeof(List<Author>));
            List<Author> authors;
            using (var reader2 = new StreamReader(@"C:\code\c#\прога\ekz\ekz\authors.xml"))
            {
                authors = (List<Author>)xmlDeserialize2.Deserialize(reader2);
            }
            var xmlDeserialize3 = new XmlSerializer(typeof(List<ArticleData>));
            List<ArticleData> articlesData;
            using (var reader3 = new StreamReader(@"C:\code\c#\прога\ekz\ekz\articleDatas.xml"))
            {
                articlesData = (List<ArticleData>)xmlDeserialize3.Deserialize(reader3);
            }
            var allData = from artc in articles
                          join auth in authors on artc.AuthorId equals auth.Id
                          join aD in articlesData on artc.Id equals aD.ArticleId
                          orderby aD.Year
                          select new
                          {
                              artc.Id,
                              artc.AuthorId,
                              artc.Title,
                              auth.LastName,
                              auth.FirstName,
                              auth.Country,
                              aD.Year,
                              aD.RealaseNumber
                          };

            /*1. Отримати csv-файл, де (використовуючи впорядкування у спадному
порядку за роками i номерами) для кожного номера журналу подано його

змiст у форматi <прiзвище автора, назва статтi>, впорядкований за прi-
звищем у лексико-графiчному порядку.
*/

            var allNumbers = allData.Select(x => x.RealaseNumber).Distinct().ToList();
           
            var task1 = from row in allData
                        orderby row.Year, row.RealaseNumber
                        select new { row.LastName, row.Title, row.RealaseNumber, row.Year};
            
            string PathForTask1 = "task1.csv";
            if (File.Exists(PathForTask1))
            {
                File.Delete(PathForTask1);
            }
            using StreamWriter writer = new StreamWriter(PathForTask1);
            foreach (var num in allNumbers)
            {
                writer.WriteLine(num);
                foreach (var item in task1)
                {
                    if (item.RealaseNumber == num)
                    {
                        writer.WriteLine($"\t{item.Title}\t{item.LastName}\t{item.Title}");
                    }
                }
            }

            /*2. Отримати xml-файл, де для кожного автора ( у форматi <прiзвище,
країна > у лексико-графiчному порядку без повторень ) вказано назви усiх
його статей, цей перелiк впорядкований за роками i номерами.*/


            var allAuthors = from row in allData
                             orderby row.LastName, row.Country
                             select new { row.LastName, row.Country };
            allAuthors = allAuthors.Distinct().ToList();
            var task2 = new XElement("TaskInfo",
                from row in allAuthors
                select new XElement("Author",
                       new XElement("LastName", row.LastName),
                       new XElement("Country", row.Country),
                       from dat in allData
                       orderby dat.Year, dat.RealaseNumber
                       where row.LastName == dat.LastName
                       select new XElement("Article",
                           new XElement("Title", dat.Title))
                       ));
            string PathForTask2 = "task2.xml";
            if (File.Exists(PathForTask2))
            {
                File.Delete(PathForTask2);
            }
            using StreamWriter writer2 = new StreamWriter(PathForTask2);
            writer2.WriteLine("<?xml version=\"1.0\" encoding=\"utf - 8\"?><xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            writer2.WriteLine(task2);



            /*3. Отримати xml-файл з перелiком авторiв статей, в назвi яких зустрiча-
ється задане слово, використовуючи формат <прiзвище автора, рiк, номер

випуску>. Цей перелiк впорядкувати за прiзвищем у лексико-графiчному
порядку.*/
            var task3 = new XElement("TaskInfo",
                from row in allData
                orderby row.LastName, row.Country
                where row.Title.Contains("Rain")
                orderby row.LastName
                select new XElement("Author",
                       new XElement("LastName", row.LastName),
                       new XElement("Year", row.Year),
                       new XElement("RealaseNumber", row.RealaseNumber))
                );
            string PathForTask3 = "task3.xml";
            if (File.Exists(PathForTask3))
            {
                File.Delete(PathForTask3);
            }
            using StreamWriter writer3 = new StreamWriter(PathForTask3);
            writer3.WriteLine("<?xml version=\"1.0\" encoding=\"utf - 8\"?><xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            writer3.WriteLine(task3);
        }
    }
}