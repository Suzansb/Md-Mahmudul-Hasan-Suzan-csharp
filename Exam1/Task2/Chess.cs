using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public Chess
    {
        public Chess() {
            Console.WriteLine("You are playing chess");
        }
        public StartPlay()
        {
            ChessBoard chessBoard = new ChessBoard();
            Console.WriteLine("You chess game has started");
            chessBoard.Start();

        }

        protected void StopPlay()
        {
            Console.WriteLine("Play is stopped, Calculating Winner");

        }

        protected void GetWinner()
        {
            Console.WriteLine("Player 1 is the Winner");
        }

    }
}
