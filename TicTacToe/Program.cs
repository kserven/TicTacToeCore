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

                char input = Console.ReadKey().KeyChar;
                if (input != 'y') {break;}
            }

            Console.WriteLine("\nThank you for playing!");
        }
    }
}
