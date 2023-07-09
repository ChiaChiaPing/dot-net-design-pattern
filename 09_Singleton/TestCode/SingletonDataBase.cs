using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using MoreLinq;
using Autofac;
using NUnit.Framework;
using Akkatecture.TestFixture;


namespace TestCode
{
    public interface IDataBase
    {
        int GetPopulation(string name);
    }

    public class SingletonDataBase : IDataBase
    {

        private Dictionary<string, int> capitals;

        private static int instanceCount = 0;

        public static int Count => instanceCount;

        private SingletonDataBase()
        {
            instanceCount++;
            Console.WriteLine("Intializing Database");
            capitals = File.ReadAllLines("/Users/jiajiaping/Desktop/Software_Engineer_Training/NET Framework Design Pattern/10.13_Singleton/testcode/capital.txt") // capital like data model or database
                .Batch(2)
                .ToDictionary(

                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))

            ) ;
        }


        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static Lazy<SingletonDataBase> Singletondb = new Lazy<SingletonDataBase>(()=>new SingletonDataBase());

        public static SingletonDataBase Instance => Singletondb.Value;  
        
        
    }


    public class OrdinaryDatabase : IDataBase
    {
        private Dictionary<string, int> capitals;


        public OrdinaryDatabase()
        {
            
            Console.WriteLine("Intializing Database");
            capitals = File.ReadAllLines("/Users/jiajiaping/Desktop/Software_Engineer_Training/NET Framework Design Pattern/10.13_Singleton/testcode/capital.txt") // capital like data model or database
                .Batch(2)
                .ToDictionary(

                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))

            );
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }




    public class SingleRecordFinder
    {

        public int GetTtotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach(var name in names)
            {
                result += SingletonDataBase.Instance.GetPopulation(name); // hardcode
            }
            return result;
        }



    }



    // Dependency Injection
    public class ConfigurableRecordFinder
    {


        private IDataBase database;

        public ConfigurableRecordFinder(IDataBase database) // Dependency Injecction, 這樣就可以帶入不同結構的Database，而不是只能同一個 Hardcode 的 DB 了
        {
            this.database = database ?? throw new ArgumentNullException(paramName: nameof(database)); 
        }

        public int GetTtotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += database.GetPopulation(name); // 以往是 SingletonDatabase.Insttance => dependency 會變得很強，這樣不太好，有點 Tight-Coupling 了
            }
            return result;
        }   



    }

    public class DummyDatabase : IDataBase
    {


        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {

                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3

            }[name];
        }



    }





        
    [TestFixture]
    public class SingletonTests
    {


        [Test]
        public void IsSingletonTest()
        {

            var db = SingletonDataBase.Instance;
            var db2 = SingletonDataBase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDataBase.Count, Is.EqualTo(1));
        }



    }


}
