using System;
using System.Collections;
using System.Collections.Generic;

namespace TestCode
{
    public class Person
    {
        public int Id { get; set; }     
        public string Name { get; set; }


        public override string ToString()
        {
            return $"{Id}-{Name}";
        }


    }


    public class PersonFactory
    {

        private static int Id = 0;

        public static Person CreatePerson(string Name)
        {
            return new Person { Id=Id++,Name = Name };
        }

       

    }


}
