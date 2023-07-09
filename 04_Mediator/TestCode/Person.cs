using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCode
{
    public class Person
    {
        public string Name;
        public ChatRoom Room ;
        private List<string> Chatlog = new List<string>(); // for everyone's talking


        public Person(string name)
        {
            Name = name;
            

        }

        public void Say(string something) {

            Room.Broadcast(Name, something);

        }

        public void PrivateMessage(string who, string message) {

            Room.Message(Name, who, message);

        }

        // show the sender and message of a specific message    
        public void Receive(string sender,string message)
        {
            string s = $"{sender}: {message}";
            Chatlog.Add(s);
            Console.WriteLine($"[{Name}'s chat session] {s}"); // session 代表收件人的聊天訊息    
        }


    }

    public class ChatRoom // this is mediator component to let eacch individual ccomponent can communicatte eacch other
    {
        private List<Person> people = new List<Person>();

        public void Join(Person p)
        {
            string joinMessage = $"{p.Name} joins the chat";
          
            Broadcast("room", joinMessage);
            p.Room = this;
            people.Add(p);   
        }
        public void Broadcast(string source,string message)
        {
            foreach(var p in people)
            {
                if (p.Name != source) // broadcast except for source
                {
                    p.Receive(source, message);
                }
            }
        }

        public void Message(string source,string destination,string message)
        {
            people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message); // why ?, because probably it will be null

        }

    }
}
