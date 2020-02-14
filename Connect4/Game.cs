using System;
using System.Collections.Generic;
using System.Text;

namespace Connect4
{
    public class Game
    {
        private bool isOver;
        private Grid grid;
        private char Player;
        private int nbGame;

        public Game()
        {
            isOver = false;
            nbGame = 1;
            Player = '1';
            grid = new Grid();
        }

        public void Play()
        {
            if (isOver)
            {
                isOver = false;
                nbGame++;
                Player = (Player != '1') ? '1' : '2';
                grid.Reset();
            }

            while (!isOver)
            {
                grid.GetNextMove(Player);

                isOver = grid.IsFull() || grid.CheckWin(Player);

                Player = (Player != '1') ? '1' : '2';
            }

            Console.Clear();
            grid.Print();
            Console.WriteLine();
            int winner = grid.GetWinner();

            if (winner == 1)
                Console.WriteLine("Player 1 wins !");
            else if (winner == 2)
                Console.WriteLine("Player 2 wins !");
            else
                Console.WriteLine("Draw");
        }
    }
}
