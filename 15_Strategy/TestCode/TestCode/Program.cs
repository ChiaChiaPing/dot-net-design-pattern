using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime;   


namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // static strategy => 只做指定的策略(泛行    )
            var tp = new TextProcessor<MarkerDownStrategy>();

            // dynacic strategy => 會根據不同的input 做出不同的策略
            tp.SetOutputFormat(OutputFormat.MarkedDown);
            tp.AddItem(new string[] { "Fool", "Aple" });
            Console.WriteLine(tp);


            // Equality and Comparison Strategy, (ex: 可以自定義一個排序方式 給 s   存放ccustomized;s object 的list )
            var people = new List<Person>() { new Person(2, 10, "kevin"), new Person(1, 2, "cathy") };
            people.Sort((x, y) => x.Name.CompareTo(y.Name));
            var sortedList = people.OrderBy(x => x.Id);
            foreach(var p in sortedList)
            {
                Console.WriteLine(p.Name);
            }

        }
    }
}
