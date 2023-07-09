using System;
using Autofac;

namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var cb = new ContainerBuilder();
            cb.RegisterType<BankAccount>(); // 集中註册
            cb.RegisterType<NullLog>().As<ILog>();
            //cb.RegisterType<ConsoleLog>().As<ILog>();
            using (var c = cb.Build()){
                var ba = c.Resolve<BankAccount>();
                ba.Deposit(200);

            }

            Console.WriteLine(default(int));
        }
    }
}
