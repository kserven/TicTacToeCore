using System;

namespace TicTacToe
{
    internal class Board
    {
        private string[,] _board;

        public void InitializeBoard()
        {
            _board = new string[,]
            {
                { "1", "2", "3"},
                { "4", "5", "6"},
                { "7", "8", "9"}
            };
        }
        public void DrawBoard()
        {
            const string a = "     |     |\n";
            const string b = "  {0}  |  {1}  |  {2}\n";
            const string c = "_____|_____|_____\n";

            Console.Clear();
            Console.Write(a + b + c + a, _board[0, 0], _board[0, 1], _board[0, 2]);
            Console.Write(b + c + a, _board[1, 0], _board[1, 1], _board[1, 2]);
            Console.WriteLine(b + a, _board[2, 0], _board[2, 1], _board[2, 2]);
        }
        public int DetectWin()
        {
            for (int index = 0; index < 3; index++)
            {
                if (_board[index, 0].Equals("X") && _board[index, 1].Equals("X") && _board[index, 2].Equals("X"))
                {
                    return 1;
                }

                if (_board[index, 0].Equals("O") && _board[index, 1].Equals("O") && _board[index, 2].Equals("O"))
                {
                    return 2;
                }

                if (_board[0, index].Equals("X") && _board[1, index].Equals("X") && _board[2, index].Equals("X"))
                {
                    return 1;
                }

                if (_board[0, index].Equals("O") && _board[1, index].Equals("O") && _board[2, index].Equals("O"))
                {
                    return 2;
                }
            }

            if (_board[0, 0].Equals("X") && _board[1, 1].Equals("X") && _board[2, 2].Equals("X"))
            {
                return 1;
            }
            if (_board[0, 0].Equals("O") && _board[1, 1].Equals("O") && _board[2, 2].Equals("O"))
            {
                return 2;
            }
            if (_board[0, 2].Equals("X") && _board[1, 1].Equals("X") && _board[2, 0].Equals("X"))
            {
                return 1;
            }
            if (_board[0, 2].Equals("O") && _board[1, 1].Equals("O") && _board[2, 0].Equals("O"))
            {
                return 2;
            }

            int count = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (_board[row, col].Equals("X") || _board[row, col].Equals("O")) count++;
                }

                if (count >= 9)
                {
                    return 4;
                }
            }

            return 0;
        }
        public void MainLoop()
        {
            int player = 1;
            int winner = 0;

            string message = "";

            while (winner == 0)
            {
                DrawBoard();
                Console.Write(message);
                message = "";
                Console.Write("\nPlayer {0} choose your move: ", player);
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int result))
                {
                    continue;
                }

                if (result < 1 || result > 9)
                {
                    message = "\nPlease choose a number between 1 and 9";
                    continue;
                }

                result--;

                if (_board[result / 3, result % 3].Equals("O") || _board[result / 3, result % 3].Equals("X"))
                {
                    message = "\nThat space is already taken! Try again!";
                    continue;
                }

                if (player == 1)
                {
                    _board[result / 3, result % 3] = "X";
                    player = 2;
                }

                else if (player == 2)
                {
                    _board[result / 3, result % 3] = "O";
                    player = 1;
                }

                winner = DetectWin();
            }

            if (winner == 4)
            {
                Console.WriteLine("It is a Tie!");
            }
            else
            {
                Console.WriteLine("Player {0} is the Winner!", winner);
            }
        }
    }
}

