using System;
using System.Net;
using System.Text;
using System.Linq;


namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // object intialized only once
            var db = SingletonDataBase.Instance;
            Console.WriteLine(db.GetPopulation("Tokyo"));


            // MonoState
            var ceo = new CEO();
            ceo.Age = 10;
            ceo.Age = 20;
            ceo.Name = "Kevin";
            Console.WriteLine(ceo);


            //Exercise
            var obj = SingletonClass.singletonObj;
            Console.WriteLine(TestSingleTon.IsSingleton(()=>obj));
            


        }



    }


    public class SingletonClass
    {

        private SingletonClass()
        {

        }

        private static Lazy<SingletonClass> obj = new Lazy<SingletonClass>(()=>new SingletonClass());

        public static SingletonClass singletonObj => obj.Value;

    }

    public class TestSingleTon
    {


        public static bool IsSingleton(Func<SingletonClass> func)
        {
            var obj = func();
            return obj == SingletonClass.singletonObj;
        }


    }

   
}
