using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    public class Paper
    {
        private string name_publ;
        private Person author;
        private System.DateTime DATE;



        public Paper()
        {

        }
        public Paper(string name_publ, Person author, DateTime DATE)
        {
            this.name_publ = name_publ;
            this.author = author;
            this.DATE = DATE;

        }
        public string name_publ1
        {
            get { return name_publ; }
            set { name_publ = value; }
        }
        public Person author1
        {
            get { return author; }
            set { author = value; }
        }
        public DateTime DATE1
        {
            get { return DATE; }
            set { DATE = value; }

        }
        public virtual string ToString()
        {
            return this.name_publ;
        }


        class ExPaper : Paper
        {
            public override string ToString()
            {
                return this.name_publ + " " + this.author + " " + this.DATE;
            }

        }
        public virtual object DeepCopy()
        {
            return new Paper(name_publ1, author1, DATE1);
        }
    }
}
