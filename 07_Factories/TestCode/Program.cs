using System;
using System.Linq;
using System.Net;
using System.Data;
using System.Collections.Generic;
using System.Collections;

namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // Abstract Factories : 可以利用抽象工廠的方式去建立物件
            /*
            var drinkMachine = new HotDrinkMachine();
            var drink = drinkMachine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 2);
            drink.Consume();*/

            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.Consume();


            Enumerable.Range(0, 10).ToList().ForEach((int a) =>
            {

                var p = PersonFactory.CreatePerson("Kevin");
                Console.WriteLine(p);


            });



        }
    }


    // open for extension , close for modification
    public class Chocolate : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Chocolate is great");
        }
    }

    public class ChocolateFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Please input {amount} chocolate cake good");
            return new Chocolate();

        }
    }



}
