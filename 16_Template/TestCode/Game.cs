using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.IO;


namespace TestCode
{
    public abstract class Game
    {
        protected int currentPlayer;
        protected readonly int numberOfPlayers;


        // 抽象類別可以有建構子方法, 雖然不能建立物件, 但是可以當子類別建立物件時所呼叫到父類別的預設建構子而引用
        protected Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;

        }

        protected abstract void Start();
        protected abstract void TakeTurn();
        protected abstract bool HaveWinner();
        protected abstract int WinningPlayer { get; }


        public void Run()
        {

            Start();
            while (!HaveWinner())
            {
                TakeTurn();
            }
            Console.WriteLine($"Player {WinningPlayer} wins");

        }

    }

    public class Chess : Game
    {

        private int turn = 1;
        private int maxTurns = 10;

        public Chess() : base(2) { }

        protected override void Start()
        {
            Console.WriteLine($"Start Game of chess with {numberOfPlayers} players.");
        }
        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }
        protected override bool HaveWinner() => turn == maxTurns;

        protected override int WinningPlayer => currentPlayer;
    }

    public class Game1
    {
        // Action var => No parameter and no returned value
        public static void Run(Action Start,Action takeTurn, Func<bool> haveWinner,Func<int> winnerPlayer)
        {
            Start();
            while (!haveWinner())
                takeTurn();
            Console.WriteLine($"Winner:{winnerPlayer()}");



        }
    }


}
