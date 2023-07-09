using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;

namespace TestCode
{
    class Program
    {

        private static bool pr;
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            /*
            var ba = new BankAccount(100);
            Console.WriteLine(ba);

            var sequentialAction = new List<BankAccountCommand> // 把 command 用物件表示，別且去執行
            {
                new BankAccountCommand(ba,BankAccountCommand.Action.Deposit,100), // 我創不同ccommand 物件但針對同一個bank 跟續亞的參數做相對應的操作，
                new BankAccountCommand(ba,BankAccountCommand.Action.WithDraw,1000)
            };

            foreach (var c in sequentialAction)
                c.Call();

            Console.WriteLine(ba);

            foreach (var c in Enumerable.Reverse(sequentialAction))
            {
                c.Undo(); // linkedlist reverse tracking;
            }

            Console.WriteLine(ba) ;*/



            var ba = new BankAccount(100);
            var deposite = new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100);
            var withdraw = new BankAccountCommand(ba, BankAccountCommand.Action.WithDraw, 50);
            var compositeCommand = new CompositeBankAccountCommand(new BankAccountCommand[] { deposite,withdraw });
            Console.WriteLine(ba);
            compositeCommand.Call();
            compositeCommand.Undo();
            Console.WriteLine(ba);

            Console.WriteLine(new string('-',20));


            var b1 = new BankAccount(200);
            var b2 = new BankAccount(0);
            var mtc = new MoneyTransferCommand(b1, b2, 701);
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            mtc.Call();
            Console.WriteLine(b1);
            Console.WriteLine(b2);


            Console.WriteLine(new string('-', 20));

            Account account = new Account();

            var depositeCommand = new Command();
            depositeCommand.Amount = 200;
            depositeCommand.TheAction = Command.Action.Deposit;
            

            var withDrawCommand = new Command();
            withDrawCommand.Amount = 1s00;
            withDrawCommand.TheAction = Command.Action.Withdraw;

            account.Process(depositeCommand);
            Console.WriteLine(depositeCommand.Success);
            Console.WriteLine(account.Balance);

            account.Process(withDrawCommand);
            Console.WriteLine(withDrawCommand.Success);
            Console.WriteLine(account.Balance);








        }

        
    }

    
}
