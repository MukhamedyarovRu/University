using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class ResearchTeamEnumerator : IEnumerator
    {
        private ArrayList participansWithPublications;

        int position = -1;

        public ResearchTeamEnumerator(object[] participans, object[] publications)
        {
            participansWithPublications = new ArrayList();

            foreach (Person participan in participans)
            {
                bool hasPublication = false;

                foreach (Paper publication in publications)
                {
                    if (participan == publication.author1)
                    {
                        hasPublication = true;
                        break;
                    }
                }

                if (hasPublication)
                {
                    participansWithPublications.Add(participan);
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return (Person)participansWithPublications[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < participansWithPublications.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
