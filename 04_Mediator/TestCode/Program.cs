using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;


namespace TestCode
{
    static class Program
    {

        public static void Main(string[] args)
        {
            
            var room = new ChatRoom();
            var Jane = new Person("Jane");
            var Jack = new Person("Jack");

            room.Join(Jane);
            room.Join(Jack);

            Jane.Say("Hello world");
            Jack.PrivateMessage(Jane.Name, "I love you");

            Console.WriteLine(new string('-',20));

            var mediator = new Mediator();
            var p1 = new Participant(mediator);
            var p2 = new Participant(mediator);
            var p3 = new Participant(mediator);
            p1.Say(3);
            p2.Say(2);
            p3.Say(1);
            mediator.PrintOuttput();


        }



    }
}
