using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ConsoleApplication4
{
    
    class ResearchTeam : Team, INameAndCopy, IEnumerable
    {
        private string topic;
        private TimeFrame inf_duration;
        ArrayList list_publ;
        public ResearchTeam(string topic, string name_org, int reg_numb, TimeFrame inf_duration)
        {
            this.topic = topic;
            this.name_org = name_org;
            this.reg_numb = reg_numb;
            this.inf_duration = inf_duration;
            list_publ = new ArrayList();
            Participans = new ArrayList();
            
        }
        public ResearchTeam()
        {
            list_publ = new ArrayList();
        }

        public ArrayList Participans { get; set; }

        public Paper late_publ
        {
            get
            {
                if (list_publ1.Count == 0) return null;
                Paper tmp = (Paper)list_publ1[0];
                foreach (Paper x in list_publ1)
                    if (x.DATE1 > tmp.DATE1)
                        tmp = x;
                return tmp;
            }
        }
        bool Check(TimeFrame tmp)
        {
            return inf_duration == tmp;
        }

        public string topic1
        {
            get { return topic; }
            private set { topic = value; }
        }
        public string name_org1
        {
            get { return name_org; }
            private set { name_org = value; }
        }
        public int reg_numb1
        {
            get { return reg_numb; }
            private set { reg_numb = value; }
        }
        public TimeFrame inf_duration1
        {
            get { return inf_duration; }
            private set { inf_duration = value; }
        }
        public ArrayList list_publ1
        {
            get { return list_publ;}
            private set { list_publ = value; }
        }
        public void AddPapers(Paper[] param)
        {
            list_publ.AddRange(param);
        }
        public virtual string ToShortString()
        {
            return "TOPIC: " + this.topic1 + ", DURATION: " + this.inf_duration1 + ", NAME_ORG: " + this.name_org + ", REG NUM: " + this.reg_numb;
        }
        public override string ToString()
        {
            string tmp = this.ToShortString();

            foreach (Paper t in list_publ)
                tmp += "\r\n Publication: " + t.name_publ1;
            return tmp;
        }

        public override object DeepCopy()
        { 
            ResearchTeam n= new ResearchTeam();
            n.topic= topic;
            n.name_org= name_org;
            n.reg_numb=reg_numb;
            n.inf_duration= inf_duration;
            n.Participans= Participans;
            n.list_publ = (ArrayList)list_publ.Clone();
            return n;

        }

        public void AddMembers ( params Person[] x)
        {
            Participans.AddRange(x);
        }

        public Team Team
        {
            get 
            {
                Team n = new Team(name_org, reg_numb);
                return n;
            }
            set 
            {
                Team n = value;
                name_org = n.access_name_org;
                reg_numb = n.access_reg_numb;

            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ResearchTeamEnumerator GetEnumerator()
        {
            return new ResearchTeamEnumerator(Participans.ToArray(), list_publ.ToArray());
        }

        public IEnumerable<Person> GetPersonsWithTwoOrMorePublications()
        {
            foreach (Person participan in Participans)
            {
                int publicationsCount = 0;

                foreach (Paper publication in list_publ)
                {
                    if (participan == publication.author1)
                        publicationsCount++;
                }

                if (publicationsCount > 1)
                    yield return participan;
            }
        }

        public IEnumerable<Paper> GetPublicationsForCurrentYear()
        {
            int yearNow = DateTime.Now.Year;

            foreach (Paper publication in list_publ)
            {
                if (publication.DATE1.Year == yearNow)
                {
                    yield return publication;
                }
            }
        }

        public IEnumerable<Person> GetPersonsWithoutPublications()
        {
            foreach (Person participan in Participans)
            {
                bool hasPublication = false;

                foreach (Paper publication in list_publ)
                {
                    if (participan == publication.author1)
                    {
                        hasPublication = true;
                        break;
                    }
                }

                if (!hasPublication)
                {
                    yield return participan;
                }
            }
        }

        public IEnumerable<Paper> GetPublicationsLastYears(int n)
        {
            DateTime beginYear = DateTime.Now.AddYears(-n);

            foreach (Paper publication in list_publ)
            {
                if (publication.DATE1 >= beginYear)
                {
                    yield return publication;
                }
            }
        }

    }

}

