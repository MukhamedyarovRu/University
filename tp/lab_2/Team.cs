using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Team : INameAndCopy
    {
        protected string name_org;
        protected int reg_numb;
        public Team(string name_org, int reg_numb)
        {
            this.name_org = name_org;
            this.reg_numb = reg_numb;
        }
        protected Team()
        {
        }
        public string access_name_org
        {
            get { return name_org; }
            set { name_org = value; }
        }
        public int access_reg_numb
        {
            get { return reg_numb; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Error!Invalid value! Registration number is less than or equal to zero");
                reg_numb = value;
            }
        }
        public override string ToString() //для формирования строки со значениями всех полей класса
        {
            return name_org + " " + reg_numb.ToString();
        }

        //override
        public override bool Equals(object obj)
        {
            Team buf = (Team)obj;

            if (name_org == buf.name_org && this.reg_numb == buf.reg_numb)
                return true;
            else return false;
        }

        public static bool operator ==(Team m1, Team m2)
        {
            return m1.Equals(m2);
        }
        public static bool operator !=(Team m1, Team m2)
        {
            return !m1.Equals(m2);
        }

        public override int GetHashCode()
        {
            return name_org.GetHashCode() * reg_numb.GetHashCode() ;
        }
        public virtual object DeepCopy()
        {
            Team n = new Team();
            n.name_org = name_org;
            n.reg_numb = reg_numb;
            return (object)n;
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
