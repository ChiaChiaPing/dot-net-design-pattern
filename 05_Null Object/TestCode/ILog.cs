using System;
using Autofac;

namespace TestCode
{
    public interface ILog
    {
        void Info(string message);
        void Warn(string message);

    }

    class ConsoleLog : ILog
    {
        public void Info(string mes)
        {
            Console.WriteLine(mes);
        }
        public void Warn(string mes)
        {
            Console.WriteLine("Warn : "+mes);
        }
    }

    // Null Obejct
    class NullLog : ILog
    {
        public void Info(string message) { }
        public void Warn(string message) { }
    }


    public class BankAccount
    {
        private ILog log;
        private int balance;

        public BankAccount(ILog log)
        {
            this.log = log;
        }
        public void Deposit(int amount)
        {
            this.balance += amount;
            log?.Info($"Deposited {amount}, balance is now {balance}");  
        }
    }

    // Dynamic Object
  
}
