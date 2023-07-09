using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // event keyword observer design pattern.
            var p = new Person();

            // event keyword 的variable 跟delegate 用途很像，只是差異在帶入的函數必須要在簽章的一開始定義 object sender
            // 然後去Invoke 這樣的event 時要帶入 this(Invoke 的人) 配置到object sender's parameter
            p.FallsIll += FallsIll; 

            p.CatchACold();

            // Observable Collection
            var market = new Market();
            market.Prices.ListChanged += (sender, EventArgs) =>
            {
                if (EventArgs.ListChangedType == ListChangedType.ItemAdded)
                {
                    float price = ((BindingList<float>)sender)[EventArgs.NewIndex];
                    Console.WriteLine($"Binding List got the price {price}");
                }
            };
            market.AddPrice(20);
                    




        }

        private static void FallsIll(object sender,FallsIllEventArgs eventArgs)
        {
            Console.WriteLine($"The paitent's address is {eventArgs.Address}");
        }
    }
}
