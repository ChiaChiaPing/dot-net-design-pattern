using System;
using System.Collections.Generic;

namespace TestCode
{
    public class BankAccount
    {

        private int Balance;
        private int Current;
        private List<Momento> Changes = new List<Momento>();


        public BankAccount(int balance)
        {
            this.Balance = balance;
            Changes.Add(new Momento(balance));
        }

        public Momento Deposit(int balance)
        {
            this.Balance += balance;
            var m =  new Momento(this.Balance);
            ++Current;
            Changes.Add(m);
            return m;
        }

        public Momento Restore(Momento m) // rollback To the previouse state that account change for a specific stat
        {
            if (m != null)
            {
                this.Balance = m.Balance;
                ++Current;
                Changes.Add(m);
                return m;
            }
            return null; // 如果 momento m 是 null 的話就依樣回傳null
            
            
        }

        public void Undo()
        {
            if (Current > 0)
            {
                var m = Changes[--Current];
                this.Balance = m.Balance;
            }
        }

        public void Redo()
        {
            if (Current < Changes.Count - 1)
            {
                var m = Changes[++Current];
                this.Balance = m.Balance;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Balance)}:{Balance}";
        }
    }

    // Momento 可以存放物件更動的資訊。
    public class Momento
    {
        public int Balance { get; set; }

        public Momento(int balance)
        {
            this.Balance = balance;
        }
    }
}
