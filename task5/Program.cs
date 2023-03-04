using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*На базі generic collections платформи .NET реалізувати узагальнену структуру 
даних Table<R, C, V>
R - row key
C - column key
V - value
Ця структура даних повинна забезпечувати доступ до збережених в ній значень 
по ключах R i C зі складністю O(1).
Продемонструвати роботу з цією структурою даних, створивши об'єкт колекції 
Table<FootballTeam, Tournament, HashSet<int>>.
FootballTeam(title, city, foundationYear)
Tournament(title, international: boolean, foundationYear)
HashSet<int> - містить роки, коли задана FootballTeam перемагала в турнірі Tournament.
Також навести якийсь свій власний приклад застосування цієї структури даних.*/

namespace task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table<FootballTeam, Tournament, HashSet<int>> table = new Table<FootballTeam, Tournament, HashSet<int>>();
            Tournament firstTournament = new Tournament("firstTournament", false, 2001);
            Tournament secondTournament = new Tournament("secondTournament", true, 1999);
            FootballTeam firstTeam = new FootballTeam("firstTeam", "Kyiv", 1987);
            FootballTeam secondTeam = new FootballTeam("secondTeam", "Lviv", 1963);
            FootballTeam thirdTeam = new FootballTeam("thirdTeam", "Dnipro", 1978);
            HashSet<int> first1 = new HashSet<int>();
            HashSet<int> first2 = new HashSet<int>();
            HashSet<int> second1 = new HashSet<int>();
            HashSet<int> second2 = new HashSet<int>();
            HashSet<int> third2 = new HashSet<int>();
            first1.Add(2003);
            first1.Add(2005);
            first2.Add(2010);
            second1.Add(1999);
            second1.Add(2001);
            second1.Add(2003);
            second2.Add(2008);
            third2.Add(2007);
            third2.Add(2004);
            table.Add(firstTeam, firstTournament, first1);
            table.Add(firstTeam, secondTournament, first2);
            table.Add(secondTeam, firstTournament, second1);
            table.Add(secondTeam, secondTournament, second2);
            //table.Add(secondTeam, secondTournament, second2);
            table.Add(thirdTeam, secondTournament, third2);

            Table<FootballTeam, Tournament, int> testTable = new Table<FootballTeam, Tournament, int>();
            testTable.Add(thirdTeam, secondTournament, 2003);

            Console.WriteLine(table);
            Console.WriteLine(table[firstTeam,firstTournament]);
            Console.WriteLine(testTable[thirdTeam, secondTournament]);
            Console.WriteLine(first1);

            Console.WriteLine();
            foreach (var n in table[firstTeam, firstTournament])
            {
                Console.WriteLine(n);
            }
            
        }
    }
}
