using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace TestCode
{
    public class BankAccount
    {
        public int Balance;
        private int OverDraft = -500;


        public BankAccount()
        {     
        }

        public BankAccount(int balance)
        {
            Balance = balance;
        }
        public void Deposit(int value)
        {
            Balance += value;
            Console.WriteLine($"Add {value} to the account, now {nameof(Balance)} : {Balance}");
        }

        public bool Withdraw(int value)
        {
            if (Balance - value < OverDraft)
                return false;
            else
            {
                Balance -= value;
                Console.WriteLine($"Substract {value} to the account, now {nameof(Balance)} : {Balance}");
                return true;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Balance)}:{Balance}";
        }
    }

    public interface ICommand
    {
        void Call();
        void Undo();
        bool Success { get; set; }
      
    }

    public class BankAccountCommand : ICommand
    {
        public BankAccount ba;
        public int value;
        public Action ac;
        public bool Success { get; set; }

        public enum Action
        {
            Deposit,WithDraw
        }

        public BankAccountCommand(BankAccount ba, Action ac,int value)// value is transaction data
        {
            this.ba = ba ?? throw new ArgumentNullException("Bank account");
            this.ac = ac;
            this.value = value;
        }

        public void Call()
        {
            switch (ac)
            {
                case Action.Deposit:
                    ba.Deposit(value);
                    Success = true;
                    break;
                case Action.WithDraw:
                    Success = ba.Withdraw(value);
                    break;
                default:
                    Console.WriteLine("Please input Deposit or Withdraw function, thank you");
                    break;
            }
        }

        public void Undo()
        {
            if (!Success) return;
            switch(ac)
            {
                case Action.Deposit:
                    ba.Withdraw(value);
                    break;
                case Action.WithDraw:
                    ba.Deposit(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{nameof(ac)}");
                    
                    
            }
        }
        



    }


    public class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
    {

        public CompositeBankAccountCommand()
        {

        }

        // 從外部帶一個collection 來作為這一個物件的list
        public CompositeBankAccountCommand(IEnumerable<BankAccountCommand> collection) : base(collection) { }

        public virtual void Call()
        {
            ForEach(cmd => cmd.Call());
        }

        public virtual void Undo()
        {
            foreach (var c in ((IEnumerable<BankAccountCommand>) this).Reverse())
            {
                c.Undo();
            }
        }
        public virtual bool Success
        {
            get { return this.All(cmd => cmd.Success); }
            set
            {
                foreach(var c in this)
                {
                    c.Success = value;
                }


            }
              
            
        }





    }

    public class MoneyTransferCommand : CompositeBankAccountCommand
    {

        public MoneyTransferCommand(BankAccount from,BankAccount to,int amount)
        {
            AddRange(new BankAccountCommand[] {

               new BankAccountCommand(from,BankAccountCommand.Action.WithDraw,amount),
               new BankAccountCommand(to,BankAccountCommand.Action.Deposit,amount)


           });
        }

        public override void Call()
        {

           // 基本上利用linked list 來去存放要去處理的command
            BankAccountCommand last = null; // linked list's starting point

            // this is MoneryTransfer
            foreach(var c  in this)
            {

                if (last == null || last.Success) // 當我們在做transfer ，如果雙方的第一個人 transaction 是ilegal ，那另一外的交易也不用進行，然後需要去undo 上一個人做的 ㄈ
                {
                    c.Call();
                    last = c;
                }
                else
                {
                    last.Undo();
                    break;
                    //last = c;
                }
            }
            

           
        }





    }
}
