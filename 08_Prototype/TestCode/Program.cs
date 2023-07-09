using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace TestCode
{

    
    

    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            /* Icloable
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));
            Console.WriteLine(john);

            var jane = (Person)john.Clone();
            jane.Names[0] = "Kevin";
            Console.WriteLine(jane);*/

            /* Copy consttructtor 
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));
            Console.WriteLine(john);

            var jane = new Person(john); // 把其他物件內的屬性派直到新的物件上ㄏ
            jane.Names[0] = "Jane";
            Console.WriteLine(jane);*/


            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));
            Console.WriteLine(john);
            var jane = john.DeepCopy();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;
            Console.WriteLine(jane);

            // Copy though Serization
            john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));
            Console.WriteLine(john);
            jane = john.DeepCopy();
            Console.WriteLine(jane);


            // Prototype Exercise
            var start = new Point() { X=1,Y=2};
            var end = new Point() { X = 2, Y = 4 };
            var line = new Line() { Start=start,End=end};
            Console.WriteLine(line);

            Console.WriteLine(line.DeepCopy());
            
            




        }
    }

    public class Point
    {
        public int X, Y;


        public override string ToString()
        {
            return $"{nameof(X)}:{X},{nameof(Y)}:{Y}";
        }

    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            var line = new Line();
            line.Start = Start;
            line.End = End;
            return line;
        }


        public override string ToString()
        {
            return $"Start : {Start.ToString()} - End:{End.ToString()}";
        }



    }


}
