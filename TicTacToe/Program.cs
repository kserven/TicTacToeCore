using System;

namespace TicTacToe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var board = new Board();

            while (true)
            {
                board.InitializeBoard();
                board.MainLoop();

                Console.Write("\n\nDo you want to play another game? (y/n) ");

                string input = Console.ReadLine();
                if (input != null && !input.Equals("y")) break;
            }

            Console.WriteLine("Thank you for playing!");
        }
    }
}
