using System;
using System.Text;


namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BankAccount ba = new BankAccount(100);
            var m1 = ba.Deposit(20);
            var m2 = ba.Deposit(30);
            Console.WriteLine(ba);

            ba.Restore(m1);
            Console.WriteLine(ba);
            
            ba.Undo();
            Console.WriteLine($"Undo : {ba}");

            ba.Redo();
            Console.WriteLine($"Redo : {ba}");

            // token exercise
            var t1 = new Token(3);
            var t2 = new Token(4);
            int t3 = 5;         
            var tokenMachine = new TokenMachine();
            var m11 = tokenMachine.AddToken(t1);
            var m22 = tokenMachine.AddToken(t2);
            var m33 = tokenMachine.AddToken(t3);

            Console.WriteLine(tokenMachine);

            tokenMachine.Revert(m11);
            Console.WriteLine(tokenMachine);

            


        }
    }
}
