using System;
namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine("Enter 'exit' to quit the game at any time.");

            int player1Points = 0;
            int cpuPoints = 0;

            while (true)
            {
                string playerMove = GetPlayerMove();
                if (playerMove == "exit")
                {
                    Console.WriteLine($"Score: Player - {player1Points}, CPU - {cpuPoints}");
                    break;
                }

                string cpMuove = GetCpuMove();

                int result = DetermineWinner(playerMove, cpMuove);
                if (result == 1)
                    player1Points++;
                else if (result == 2)
                    cpuPoints++;                
            }
        }

        static string GetPlayerMove()
        {
            Console.Write($"Enter your move (rock, paper, scissors): ");
            string move = Console.ReadLine().ToLower();

            while (move != "rock" && move != "paper" && move != "scissors" && move != "exit")
            {
                Console.WriteLine("Invalid move. Please enter rock, paper, or scissors.");
                move = Console.ReadLine().ToLower();
            }

            return move;
        }

        // Change return type to int: 0 = tie, 1 = player1 wins, 2 = player2 wins
        static int DetermineWinner(string player1Move, string player2Move)
        {
            if (player1Move == player2Move)
            {
                Console.WriteLine("It's a tie!");
                return 0;
            }
            else if ((player1Move == "rock" && player2Move == "scissors") ||
                     (player1Move == "paper" && player2Move == "rock") ||
                     (player1Move == "scissors" && player2Move == "paper"))
            {
                Console.WriteLine("Player 1 wins!");
                return 1;
            }
            else
            {
                Console.WriteLine("CPU wins!");
                return 2;
            }
        }

        static string GetCpuMove()
        {
            string[] moves = { "rock", "paper", "scissors" };
            Random rand = new Random();
            int index = rand.Next(moves.Length);
            Console.WriteLine($"CPU chose {moves[index]}.");
            return moves[index];
        }
    }
}

