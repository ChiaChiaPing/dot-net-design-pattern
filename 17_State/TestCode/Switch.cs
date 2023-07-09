using System;



namespace TestCode
{
    public class Switch
    {

        public State State = new OffState();
        public void On() { State.On(this); }
        public void Off() { State.Off(this); }
        
    }

    public abstract class State
    {
        public virtual void On(Switch sw)
        {
            Console.WriteLine("The Light has already been turned up.");
        }

        public virtual void Off(Switch sw)
        {
            Console.WriteLine("The Light has already beem turned off");

        }


    }

    public class OnState : State
    {
        public OnState()
        {
            Console.WriteLine("The light is turned up.");
        }

        public override void Off(Switch sw)
        {
            Console.WriteLine("Turning off the light");
            sw.State = new OffState();

        }
    }

    public class OffState : State
    {
        public OffState()
        {
            Console.WriteLine("The light is turned off.");
        }

        public override void On(Switch sw)
        {
            Console.WriteLine("Turning on the light");
            sw.State = new OnState();

        }
    }
}
