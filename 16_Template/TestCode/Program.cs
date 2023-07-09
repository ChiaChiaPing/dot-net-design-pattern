using System;

namespace TestCode
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Template Method
            var chessGame = new Chess();
            chessGame.Run();

            // Funtional Template Method
            var numberOfPlayers = 2;
            var currentPlayer = 0;
            var turn = 1;
            var maxTurns = 10;
            
            void Start() { Console.WriteLine("Game Start"); }
            void TakeTurn() { Console.WriteLine($"{turn++} taken by {currentPlayer}"); currentPlayer=(currentPlayer+1)%numberOfPlayers; }
            bool HaveWinner() { return turn == maxTurns; }
            int Winner() => currentPlayer;

            Game1.Run(Start, TakeTurn, HaveWinner, Winner); 


        }

       


    }
}
