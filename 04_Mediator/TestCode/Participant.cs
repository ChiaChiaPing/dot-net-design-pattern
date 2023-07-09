using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestCode
{
    public class Participant
    {
        public int Value { get; set; }
        public Mediator mediator;

        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
            mediator.people.Add(this);
        }

        public void Say(int n)
        {
            mediator.Brodcast(this, n);
           
        }
    }

    public class Mediator
    {
        public List<Participant> people = new List<Participant>();


        public void Brodcast(Participant p,int value)
        {
            foreach(var pe in people)
            {
                if (!pe.Equals(p))
                {
                    pe.Value += value;
                }
            }

        }

        public void PrintOuttput()
        {
            foreach(var pe in people)
            {
                System.Console.WriteLine(pe.Value);
            }
        }

    }

    
}
