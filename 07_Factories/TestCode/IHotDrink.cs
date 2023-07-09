using System;
using System.Collections;
using System.Collections.Generic;

namespace TestCode
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This Coffee is sensational");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put tea in a bag water, pour {amount} ml, add lemon..");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($" put {amount} coffee's flavor, great ");
            return new Coffee();
        }
    }


    public class HotDrinkMachine
    {

        /* Abstract Factories
        public enum AvailableDrink
        {
            Coffee,Tea,
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach(AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink))) // 取得該 enumType 裡面所有的項目
            {
                // Get Values 是取得 Enum 裡面各個 item 的 value值
                // Get name 是從 value 取得他對應前的 Name (Like Coffee<=0)
                // Activator 以動態的方式建立物件
                // CreateInstance(Type.GetType(string type)) => 直接根據 typeString 來建立對應的物件，所以要注意，必須確保該 typeString對應的 class type 存在
                var factory = (IHotDrinkFactory) Activator.CreateInstance(
                    Type.GetType("TestCode."+Enum.GetName(typeof(AvailableDrink),drink) + "Factory")
                );  

                //Console.WriteLine("TestCcode." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory");

                factories.Add(drink, factory);

            }


        }
            

        public IHotDrink MakeDrink(AvailableDrink drink,int amount)
        {
            return factories[drink].Prepare(amount);
        }
        */

        // Abstract Factories and OCP Principles
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();
        public HotDrinkMachine()    
        {
            foreach(var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                //Console.WriteLine(t.Name);
                // c.IsAssignableFrom(t) 判斷 t是否可以轉成c
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    Console.WriteLine(t.Name);
                    factories.Add(Tuple.Create(

                        t.Name.Replace("Factory",string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                        ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available drinks ");
            for (int index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                Console.WriteLine($"{index} : {tuple.Item1}"); // tuple 要取該tuple 裡面的內容值的話，可以直接用 .Item1 的方式去取值
            }

            while (true)
            {
                string s;
                if((s=Console.ReadLine()) != null && int.TryParse(s,out int i) && i>=0 && i<factories.Count) // defensive programming
                {
                    Console.WriteLine("Specify AMount");
                    s = Console.ReadLine();
                    if(s!=null && int.TryParse(s,out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }
                else
                {
                    Console.WriteLine("Please input the drink I have");
                }
                
                
            
            }



        }



    }



}
