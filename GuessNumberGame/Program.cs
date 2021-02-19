using System;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, stranger! This is the \"Guess Number\" game. It involves two players. Press \"Enter\" to start!");
            Console.ReadKey();

            //Player 1 part
            Console.WriteLine("Player 1, please, enter the integer number: ");

            string input = Console.ReadLine();

            int theNumber;

            while (!int.TryParse(input, out theNumber))
            {
                Console.WriteLine("This is not an integer number. Enter the integer number:");
                input = Console.ReadLine();
            }

            theNumber = int.Parse(input);

            Console.WriteLine("Great, the number is valid! Press \"Enter\" to continue.");
            Console.Clear();

            //Player 2 part
            Console.WriteLine("Player 2, you should guess the number of Player 1.");

            int guess;

            do
            {
                Console.WriteLine("Enter the integer number: ");
                input = Console.ReadLine();
                while (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("This is not an integer number. Enter the integer number:");
                    input = Console.ReadLine();
                }

                guess = int.Parse(input);

                if (guess > theNumber)
                {
                    Console.WriteLine("Your guess is LARGER than the number. Try again.");
                }
                else if (guess < theNumber)
                {
                    Console.WriteLine("Your guess is LESS than the number. Try again.");
                }
            } while (guess != theNumber);
            Console.WriteLine("Congratulations! You win!");
            Console.ReadKey();
        }
    }
}
