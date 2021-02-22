using System;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayerName = string.Empty;
            string secondPlayerName = string.Empty;
            string input;

            // Instructions for players
            Console.WriteLine("Hello, strangers! This is the \"Guess Number\" game. It involves two players. Press \"Enter\" to start!");
            Console.ReadKey();

            // Entering the players' names
            Console.WriteLine("Player 1, please, enter your name: ");
            input = Console.ReadLine();
            firstPlayerName = ValidateInputString(input);
            Console.WriteLine($"Nice name, {firstPlayerName}! Press \"Enter\" to continue!");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Player 2, please, enter your name: ");
            input = Console.ReadLine();
            secondPlayerName = ValidateInputString(input);
            Console.WriteLine($"Cool, {secondPlayerName}! Press \"Enter\" to continue!");
            Console.ReadKey();
            Console.Clear();

            // Setting the limiter of attempts
            Console.WriteLine("Before you start to play, please, set the maximum number of attempts:");
            input = Console.ReadLine();
            input = ValidateInputIntegerNumber(input);
            int attemptLimiter = int.Parse(input);
            Console.WriteLine("Press \"Enter\" to start the game.");
            Console.ReadKey();
            Console.Clear();

            //Player 1 part
            Console.WriteLine($"{firstPlayerName}, please, enter the integer number: ");

            input = Console.ReadLine();

            input = ValidateInputIntegerNumber(input);
            int theNumber = int.Parse(input);

            Console.WriteLine("Great, the number is valid! Press \"Enter\" to continue.");
            Console.ReadKey();
            Console.Clear();

            //Player 2 part
            Console.WriteLine($"{secondPlayerName}, you should guess the number of {firstPlayerName}. You have {attemptLimiter} attempts.");

            int guess;
            int attemptCounter = 0;

            do
            {
                if (attemptCounter == attemptLimiter)
                {
                    Console.WriteLine($"You loose, {secondPlayerName}! You spent all {attemptLimiter} attempts.");
                    break;
                }
                attemptCounter++;
                Console.WriteLine($"Attempt #{attemptCounter}");
                Console.WriteLine("Enter the integer number: ");
                input = Console.ReadLine();
                input = ValidateInputIntegerNumber(input);
                guess = int.Parse(input);

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
                    Console.WriteLine($"Congratulations, {secondPlayerName}! You win!");
                    Console.WriteLine($"You spent {attemptCounter} out of {attemptLimiter} attempts.");
                }
            } while (guess != theNumber);
            
            Console.ReadKey();
        }
        /// <summary>
        /// Checks whether input string is convertable to integer. If no, requires to input again and checks again.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>String convertable to integer.</returns>
        public static string ValidateInputIntegerNumber(string str)
        {
            int theNumber;
            while (!int.TryParse(str, out theNumber))
            {
                Console.WriteLine("This is not an integer number. Enter the integer number:");
                str = Console.ReadLine();
            }
            return str;
        }
        /// <summary>
        /// Check whether input string is null, empty string or whitespace. If yes, requires to input again and repeats the check.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>String which is not null, empty string or whitespace.</returns>
        public static string ValidateInputString(string str)
        {
            bool isValid = false;
            while (!isValid)
            {
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                {
                    isValid = true;
                    break;
                }
                Console.WriteLine("Your name cannot be an empty string or whitespace. Please, enter it again: ");
                str = Console.ReadLine();
            }
            return str;
        }
    }
}
