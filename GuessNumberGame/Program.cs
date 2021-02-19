using System;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instructions for players
            Console.WriteLine("Hello, strangers! This is the \"Guess Number\" game. It involves two players. Press \"Enter\" to start!");
            Console.ReadKey();

            // Setting the limiter of attempts
            Console.WriteLine("Before you start to play, please, set the maximum number of attempts:");
            string input = Console.ReadLine();
            int attemptLimiter = ValidateInput(input);
            Console.WriteLine("Press \"Enter\" to start the game.");
            Console.ReadKey();
            Console.Clear();

            //Player 1 part
            Console.WriteLine("Player 1, please, enter the integer number: ");

            input = Console.ReadLine();

            int theNumber = ValidateInput(input);

            Console.WriteLine("Great, the number is valid! Press \"Enter\" to continue.");
            Console.ReadKey();
            Console.Clear();

            //Player 2 part
            Console.WriteLine($"Player 2, you should guess the number of Player 1. You have {attemptLimiter} attempts.");

            int guess;
            int attemptCounter = 0;
            do
            {
                if (attemptCounter == attemptLimiter)
                {
                    Console.WriteLine($"You loose! You spent all {attemptLimiter} attempts.");
                    break;
                }
                attemptCounter++;
                Console.WriteLine($"Attempt #{attemptCounter}");
                Console.WriteLine("Enter the integer number: ");
                input = Console.ReadLine();
                guess = ValidateInput(input);

                if (guess > theNumber)
                {
                    Console.WriteLine("Your guess is LARGER than the number. Try again.\n");
                }
                else if (guess < theNumber)
                {
                    Console.WriteLine("Your guess is LESS than the number. Try again.\n");
                }
                else
                {
                    Console.WriteLine("Congratulations! You win!");
                    Console.WriteLine($"You spent {attemptCounter} out of {attemptLimiter} attempts.");
                }
            } while (guess != theNumber);
            
            Console.ReadKey();
        }
        public static int ValidateInput(string str)
        {
            int theNumber;
            while (!int.TryParse(str, out theNumber))
            {
                Console.WriteLine("This is not an integer number. Enter the integer number:");
                str = Console.ReadLine();
            }
            return int.Parse(str);
        }
    }
}
