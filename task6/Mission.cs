using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    internal class Mission
    {   //Mission(title, start:DateTime, end:DateTime, crew: List<Astronaut>, spaceship)
        private string title;
        private DateTime start;
        private DateTime end;
        private List<Astronaut> crew;
        private Spaceship spaceship;

        public string Title { get { return title; } set { title = value; } }    
        public DateTime Start { get { return start; } set { start = value; } }  
        public DateTime End { get { return end; } set { end = value; } }    
        public List<Astronaut> Crew { get { return crew; } set { crew = value; } }      
        public Spaceship Spaceship { get { return spaceship; } set { spaceship = value; } }

        public Mission()
        {
            title = String.Empty;
            start = default(DateTime);
            end = default(DateTime);
            crew = new List<Astronaut>();
            spaceship = new Spaceship();
        }
        public Mission(string title, DateTime start, DateTime end, List<Astronaut> crew, Spaceship spaceship)
        {
            this.title = title;
            this.start = start;
            this.end = end;
            this.crew = crew;
            this.spaceship = spaceship;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine($"{title}\t{start.ToShortDateString()}\t{end.ToShortDateString()}\t{spaceship.Title}\t{crew[0].Name[0]}.{crew[0].Surname}");
            
            for (int i = 1; i < crew.Count; i++)
            {
                res.AppendLine($"{new string(' ', title.Length)}\t{new string(' ', start.ToShortDateString().Length)}\t{new string(' ', end.ToShortDateString().Length)}\t{new string(' ', spaceship.Title.Length)}\t{crew[i].Name[0]}.{crew[i].Surname}");
            }
            return res.ToString();
        }
        public override bool Equals(object obj)
        {
            return obj is Mission otherMission && Title == otherMission.Title
                && Start == otherMission.Start && End == otherMission.End
                && Crew == otherMission.Crew && Spaceship == otherMission.Spaceship;
        }
    }
}
