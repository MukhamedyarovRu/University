using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prepare buffer variables
            Person[] people = new Person[] {
                new Person("VASYA","PUPKIN",DateTime.Now),
                new Person("KOLYA","PUPKIN",DateTime.Now),
                new Person("VITYA","PUPKIN",DateTime.Now),
                new Person("ISLAM","PUPKIN",DateTime.Now)
            };

            Paper[] publications = new Paper[] {
                new Paper("PUBLIC #1", people[0], DateTime.Now),
                new Paper("PUBLIC #2", people[0], new DateTime(2006, 1, 1)),
                new Paper("PUBLIC #3", people[1], DateTime.Now),
            };

            // Tasks
            Team obj = new Team("Unicorn", 1104);
            Team obj1 = new Team("Unicorn", 1104);

            if (obj == obj1 && !object.ReferenceEquals(obj, obj1))
            {
                Console.WriteLine("Хэш код для команды: " + obj.GetHashCode() + ", и: " + obj1.GetHashCode());
            }

            Console.WriteLine();
            try
            {
                obj.access_reg_numb = -3123123;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            Console.WriteLine();

            ResearchTeam team = new ResearchTeam("TOPIC", "OOO ORG_NAME", 23, TimeFrame.Year);
            team.AddMembers(people);
            team.AddPapers(publications);

            Console.WriteLine("INFO ABOUT RESEARCH TEAM: " + team.ToString());
            Console.WriteLine("INFO ABOUT TEAM: " + team.Team.ToString());

            Console.WriteLine();
            ResearchTeam new_team = (ResearchTeam)team.DeepCopy();
            new_team.Team = new Team("OOO NEW ORG NAME", 44);
            new_team.AddPapers(new Paper[]{
                new Paper("PUBLIC #4",new Person("NINA","SHIFER",DateTime.Now),DateTime.Now),
                new Paper("PUBLIC #5",new Person("ZINA","STETHEM",DateTime.Now),DateTime.Now),
                new Paper("PUBLIC #6",new Person("TAMARA","WILLIS",DateTime.Now),DateTime.Now)
            });
            Console.WriteLine("INFO ABOUT OLD RESEARCH TEAM: " + team.ToString());
            Console.WriteLine("INFO ABOUT NEW RESEARCH TEAM: " + new_team.ToString());

            Console.WriteLine();
            Console.WriteLine("PARTICIPANS, WHOM HAS NOT PUBLICATIONS");

            foreach (Person participan in team.GetPersonsWithoutPublications())
            {
                Console.WriteLine(participan.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("PUBLICATIONS FOR LAST TWO YEARS");

            foreach (Paper publication in team.GetPublicationsLastYears(2))
            {
                Console.WriteLine(publication.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("PARTICIPANS, WHOM HAS PUBLICATIONS");

            foreach (Person participan in team)
            {
                Console.WriteLine(participan.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("PARTICIPANS, WHOM HAVE MORE THAN ONE PUBLICATION");

            foreach (Person participan in team.GetPersonsWithTwoOrMorePublications())
            {
                Console.WriteLine(participan.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("PUBLICATIONS FOR LAST YEAR");

            foreach (Paper publication in team.GetPublicationsForCurrentYear())
            {
                Console.WriteLine(publication.ToString());
            }

            Console.ReadKey();
        }
    }
}
