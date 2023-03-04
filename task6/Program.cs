using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    internal class Program
    {
        /*Дано список здійснених космічних місій. 
          Космічна місія описується такими типами даних:
            Astronaut(name, surname, birthYear)
            Spaceship (title, yearOfManufacture)
            Mission(title, start:DateTime, end:DateTime, crew: List<Astronaut>, spaceship)
          Використовуючи LINQ виконати наступне:
          1. Вивести загальну тривалість всіх місій, 
             вивести дані про місію, яка тривала найдовше.
          2. Для кожного астронавта вивести місії, в яких він брав участь і 
             його загальний час перебування в космосі
          3. Для космічного корабля, місія якого тривала найдовше, 
             вивести всі його місії посортовані по зростанню за їхньою тривалістю.
          4. Вводимо період часу в роках (наприклад 1968-1970), 
             сформувати і вивести список астронавтів, які здійснювали польоти в ці роки.
          5. Вивести космічний корабель, який мав найбільше років 
             експлуатації на момент його останнього виходу в космос.*/
        static void Main(string[] args)
        {
            DateTime start = DateTime.Parse("2002/12/22 12:00:05");
            DateTime end = DateTime.Parse("2004/10/20 22:17:34");
            List<Astronaut> crew1 = new List<Astronaut>()
            {
                new Astronaut() { Name = "Jack", Surname = "Bird", BirthYear = 1976 } ,
                new Astronaut() { Name = "Olivia", Surname = "Bean", BirthYear = 1981 } ,
                new Astronaut() { Name = "Lorenzo", Surname = "Jacobs", BirthYear = 1982 } 
            };
            Spaceship spaceship1 = new Spaceship("Cloud", 2001);
            Mission first = new Mission("first", start, end, crew1, spaceship1);

            start = DateTime.Parse("2008/05/12 14:10:34");
            end = DateTime.Parse("2010/11/23 23:07:45");
            List<Astronaut> crew2 = new List<Astronaut>()
            {
                new Astronaut() { Name = "Paris", Surname = "Robins", BirthYear = 1966 } ,
                new Astronaut() { Name = "Olivia", Surname = "Bean", BirthYear = 1981 } ,
                new Astronaut() { Name = "Jack", Surname = "Bird", BirthYear = 1976 } ,
                new Astronaut() { Name = "Tomos", Surname = "Shelton", BirthYear = 1971 } 
            };
            Spaceship spaceship2 = new Spaceship("lightning", 1999);
            Mission second = new Mission("second",start, end, crew2, spaceship2);

            start = DateTime.Parse("2000/02/16 00:17:38");
            end = DateTime.Parse("2003/10/14 08:56:57");
            List<Astronaut> crew3 = new List<Astronaut>()
            {
                new Astronaut() { Name = "Rachele", Surname = "Lim", BirthYear = 1967 } ,
                new Astronaut() { Name = "Paris", Surname = "Robins", BirthYear = 1966 } ,
                new Astronaut() { Name = "Zayd", Surname = "Hodge", BirthYear = 1976 } ,
                new Astronaut() { Name = "Tomos", Surname = "Shelton", BirthYear = 1971 } ,
                new Astronaut() { Name = "Keziah", Surname = "Sheehan", BirthYear = 1969 } 
            };
            Spaceship spaceship3 = new Spaceship("Star", 1999);
            Mission third = new Mission("third", start, end, crew3, spaceship3);

            start = DateTime.Parse("1999/01/15 23:05:55");
            end = DateTime.Parse("2006/07/21 04:10:01");
            List<Astronaut> crew4 = new List<Astronaut>()
            {
                new Astronaut() { Name = "Wilma", Surname = "Wright", BirthYear = 1967 } ,
                new Astronaut() { Name = "Rio", Surname = "Sutton", BirthYear = 1966 } ,
                new Astronaut() { Name = "Ameen", Surname = "Beattie", BirthYear = 1976 } 
            };
            Mission fourth = new Mission("fourth", start, end, crew4, spaceship2);
            Mission[] missions = { first, second, third, fourth};
            foreach (var mission in missions)
            {
                Console.WriteLine(mission);
            }

            //1. Вивести загальну тривалість всіх місій, 
            //   вивести дані про місію, яка тривала найдовше.
            Console.WriteLine("--1---------------------------------------------------------------");
            var totalTimeOfAllMissions = missions.Sum(x => (x.End - x.Start).Days);
            Console.WriteLine($"Загальна тривалiсть всiх мiсiй: {totalTimeOfAllMissions} днiв.");
            var longestMission = missions.Where(x => (x.End - x.Start).Days == missions.Max(y => (y.End - y.Start).Days));
            Console.WriteLine($"Мiсiя, яка тривала найдовше:");
            foreach (var item in longestMission)
            {
                Console.WriteLine(item);
            }
            //2. Для кожного астронавта вивести місії, в яких він брав участь і 
            //   його загальний час перебування в космосі
            Console.WriteLine("--2---------------------------------------------------------------");
            var astronauts = missions.SelectMany(x => x.Crew).Distinct().ToList();
            foreach (var astronaut in astronauts)
            {
                var astronautsMissions = missions.Where(x => x.Crew.Contains(astronaut));
                var astronautsTotalTimeInSpace = missions.Where(x => x.Crew.Contains(astronaut)).Select(t => (t.End - t.Start).Days);
                Console.WriteLine($"{astronaut.Name} {astronaut.Surname} : {astronautsTotalTimeInSpace.Sum()} days");
                foreach (var mission in astronautsMissions)
                {
                    Console.Write($"{mission.Title}   ");
                }
                Console.WriteLine("\n");
            }
            //3. Для космічного корабля, місія якого тривала найдовше, 
            //   вивести всі його місії посортовані по зростанню за їхньою тривалістю.
            Console.WriteLine("--3---------------------------------------------------------------");
            Spaceship spaceshipWithLongestMission = new Spaceship();
            foreach (var item in longestMission)
            {
                spaceshipWithLongestMission = item.Spaceship;
            }
            Console.WriteLine($"Kосмiчний корабель, мiсiя якого тривала найдовше: {spaceshipWithLongestMission.Title}");
            var spaceshipMissions = missions.Where(x => x.Spaceship.Title == spaceshipWithLongestMission.Title).OrderBy(t => (t.End - t.Start).Days);
            foreach (var item in spaceshipMissions)
            {
                Console.WriteLine(item);
            }
            //4. Вводимо період часу в роках (наприклад 1968-1970), 
            //   сформувати і вивести список астронавтів, які здійснювали польоти в ці роки.
            Console.WriteLine("--4---------------------------------------------------------------");
            //int startYear = 2002;
            //int endYear = 2010;
            Console.Write("Ввeдiть перiод часу в роках: ");
            string[] str = Console.ReadLine().Split('-');
            int startYear = int.Parse(str[0]);
            int endYear = int.Parse(str[1]);
            var listOfAstronauts = missions.Where(x => (x.Start.Year >= startYear && x.End.Year <= endYear)).SelectMany(y => y.Crew).Distinct().ToList();
            Console.WriteLine("Cписок астронавтiв, якi здiйснювали польоти в цi роки:");
            foreach (var item in listOfAstronauts)
            {
                Console.WriteLine(item);
            }
            //5. Вивести космічний корабель, який мав найбільше років 
            //   експлуатації на момент його останнього виходу в космос.
            Console.WriteLine("--5---------------------------------------------------------------");
            var mostYearsOperation = missions.Select(x => x.End.Year - x.Spaceship.YearOfManufacture).Max();
            var oldestSpaceship = missions.Where(x => x.End.Year - x.Spaceship.YearOfManufacture == mostYearsOperation);
            foreach (var item in oldestSpaceship)
            {
                Console.WriteLine("Kорабель, який мав найбiльше рокiв експлуатацii на момент його останнього виходу в космос: ");
                Console.WriteLine(mostYearsOperation);
                Console.WriteLine(item);
            }
        }
    }
}
