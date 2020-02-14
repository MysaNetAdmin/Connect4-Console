using System;
using System.Collections.Generic;
using System.Text;

namespace Connect4
{
    public class Grid
    {
        private char[,] grid;

        private int ScorePlayer1 = 0;
        private int ScorePlayer2 = 0;

        public Grid()
        {
            grid = new char[6, 7];

            Reset();
        }

        public void Reset()
        {
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    grid[x, y] = ' ';
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (j == 0)
                        Console.Write(" ");

                    if (grid[i, j] == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O");
                        Console.ResetColor();
                    }
                    else if (grid[i, j] == '2')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("O");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(grid[i, j]);

                    if (j != 6)
                        Console.Write(" | ");
                }

                if (i == 1)
                    Console.WriteLine("    -- Scoreboard --");
                else if (i == 3)
                    Console.WriteLine($"       Player 1: {ScorePlayer1}");
                else if (i == 4)
                    Console.WriteLine($"       Player 2: {ScorePlayer2}");
                else
                    Console.WriteLine();
            }
        }

        private bool CheckVertically(char Player)
        {
            for (int x = 0; x < 6 - 3; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    if (grid[x, y] == grid[x + 1, y] &&
                        grid[x + 1, y] == grid[x + 2, y] &&
                        grid[x + 2, y] == grid[x + 3, y] &&
                        grid[x, y] == Player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        private bool CheckHorizontally(char Player)
        {
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 7 - 3; y++)
                {
                    if (grid[x, y] == grid[x, y + 1] &&
                        grid[x, y + 1] == grid[x, y + 2] &&
                        grid[x, y + 2] == grid[x, y + 3] &&
                        grid[x, y] == Player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckDiagonally(char Player)
        {
            for (int x = 0; x < 6 - 3; x++)
            {
                for (int y = 0; y < 7 - 3; y++)
                {
                    if (grid[x, y] == grid[x + 1, y + 1] &&
                        grid[x + 1, y + 1] == grid[x + 2, y + 2] &&
                        grid[x + 2, y + 2] == grid[x + 3, y + 3] &&
                        grid[x, y] == Player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckWin(char Player)
        {
            return CheckVertically(Player) || CheckHorizontally(Player) || CheckDiagonally(Player);
        }

        public int GetWinner()
        {
            if (CheckWin('1'))
            {
                ScorePlayer1++;
                return 1;
            }
            else if (CheckWin('2'))
            {
                ScorePlayer2++;
                return 2;
            }

            return 0;
        }

        public bool IsFull()
        {
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    if (grid[x, y] == ' ')
                        return false;
                }
            }

            return true;
        }

        private int GetEmptyCase()
        {
            for (int y = 0; y < 7; y++)
            {
                if (grid[0, y] == ' ')
                    return y;
            }

            return 0;
        }

        public void GetNextMove(char Player)
        {
            ConsoleKey key = ConsoleKey.A;

            int x = 0;
            int y = GetEmptyCase();

            while (key != ConsoleKey.Enter)
            {
                if (key == ConsoleKey.RightArrow)
                {
                    do
                    {
                        y = (y + 1) % 7;
                    }
                    while (grid[x, y] != ' ');
                        
                }

                else if (key == ConsoleKey.LeftArrow)
                {
                    do
                    {
                        y = (y - 1) % 7;
                        if (y == -1)
                            y = 6;
                    } while (grid[x, y] != ' ');
                }

                Console.Clear();
                Console.WriteLine($"Player {Player} turn\n");                
                for (int i = 0; i < 7; i++)
                {
                    if (i == 0)
                        Console.Write(" ");

                    if (i == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(" ");

                    Console.Write("   ");
                }
                Console.WriteLine();
                Print();

                key = Console.ReadKey().Key;
            }

            while (x < 6 && grid[x, y] == ' ')
            {
                grid[x, y] = Player;
                Console.Clear();
                Console.WriteLine($"Player {Player} turn\n");
                Print();
                System.Threading.Thread.Sleep(100);
                grid[x, y] = ' ';
                x++;
            }

            if (x == 6)
                x = 5;
            else
                x--;

            grid[x, y] = Player;
        }
    }
}
