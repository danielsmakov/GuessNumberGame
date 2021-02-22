using System;
using System.Collections.Generic;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayerName;
            string secondPlayerName;
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

            //Part of Player 1
            Console.WriteLine($"{firstPlayerName}, please, enter the integer number: ");

            input = Console.ReadLine();

            input = ValidateInputIntegerNumber(input);
            int theNumber = int.Parse(input);

            Console.WriteLine("Great, the number is valid! Press \"Enter\" to continue.");
            Console.ReadKey();
            Console.Clear();

            //Part of Player 2
            Console.WriteLine($"{secondPlayerName}, you should guess the number of {firstPlayerName}. You have {attemptLimiter} attempts.");

            int guess;
            int attemptCounter = 0;
            Dictionary<int, string> attemptHistory = new Dictionary<int, string>();

            do
            {
                if (attemptCounter == attemptLimiter)
                {
                    Console.WriteLine($"You loose, {secondPlayerName}! You spent all {attemptLimiter} attempts.");
                    break;
                }

                attemptCounter++;

                //Checks if the attemptHistory list is empty. If not, outputs the following message.
                if (attemptHistory.Count != 0)
                {
                    Console.WriteLine("You already tried the following numbers:");
                }

                // Outputs the history of attempts
                foreach (KeyValuePair<int, string> kvp in attemptHistory)
                {
                    Console.WriteLine(kvp.Key + " - " + kvp.Value);
                }

                Console.WriteLine($"Attempt #{attemptCounter}");
                Console.WriteLine("Enter the integer number: ");
                input = Console.ReadLine();
                input = ValidateInputIntegerNumber(input);
                guess = int.Parse(input);

                // Evalueates the current guess
                if (guess > theNumber)
                {
                    try
                    {
                        attemptHistory.Add(guess, "LARGER");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine($"{secondPlayerName}, you already entered this number! Try another one. (Press \"Enter\" to continue.)");
                        Console.ReadKey();
                        Console.Clear();
                        attemptCounter--;
                        continue;
                    }
                    Console.WriteLine("Your guess is LARGER than the number. Try again.\n");
                    Console.Clear();
                }
                else if (guess < theNumber)
                {
                    try
                    {
                        attemptHistory.Add(guess, "LESS");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine($"{secondPlayerName}, you already entered this number! Try another one. (Press \"Enter\" to continue.)");
                        Console.ReadKey();
                        Console.Clear();
                        attemptCounter--;
                        continue;
                    }
                    Console.WriteLine("Your guess is LESS than the number. Try again.\n");
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Congratulations, {secondPlayerName}! You win!");
                    Console.WriteLine($"You spent {attemptCounter} out of {attemptLimiter} attempts.");
                }
                
            } while (guess != theNumber);
            
            Console.ReadKey();
            Environment.Exit(0);
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
