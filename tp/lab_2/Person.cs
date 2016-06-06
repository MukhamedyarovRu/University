using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    public class Person
    {
        private string name;
        private string surname;
        private System.DateTime birthday;
        public Person()
        {

        }
        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public int B
        {
            get { return birthday.Year; }
            set { birthday.AddYears(value); }
        }

       public override string ToString() //для формирования строки со значениями всех полей класса
        {
            return name + " " + surname + " " + birthday.ToString();
        }
        public  virtual string ToShortString()
        {
            return name + " " + surname;
        }
        //override
        public  bool Equals(Person obj)
        {
            if (name == obj.name && this.surname == obj.surname && this.birthday == obj.birthday)
                return true;
            else return false;
        }

        public static bool operator ==(Person m1, Person m2)
        {
            return m1.Equals(m2);
        }
        public static bool operator !=(Person m1, Person m2)
        {
            return !m1.Equals(m2);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode()* surname.GetHashCode()*birthday.GetHashCode();
        }
        public virtual object DeepCopy()
        { 
            Person n=new Person();
            n.name= name;
            n.surname= surname;
            n.birthday = birthday;
            return (object) n;
        }
    }
}

