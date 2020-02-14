using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Connect 4";

            Console.WriteLine("Welcome to Connect4 Console Game !\n");
            Console.WriteLine("Use the Left & Right arrow keys to move \nthe cursor and enter to select an emplacement\n");
            Console.WriteLine("Press ENTER to play");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
                continue;

            string restart = "y";

            Game game = new Game();

            while (restart != "n")
            {
                game.Play();

                Console.Write("Do you want to pay again ? (y/n) ");
                restart = Console.ReadLine();
            }
        }
    }
}
