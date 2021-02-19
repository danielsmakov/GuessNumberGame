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

            int theNumber = ValidateInput(input);

            Console.WriteLine("Great, the number is valid! Press \"Enter\" to continue.");
            Console.Clear();

            //Player 2 part
            Console.WriteLine("Player 2, you should guess the number of Player 1.");

            int guess;
            int guessCounter = 0;
            do
            {
                guessCounter++;
                Console.WriteLine($"Attempt #{guessCounter}");
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
            } while (guess != theNumber);
            Console.WriteLine("Congratulations! You win!");
            Console.WriteLine($"Number of attempts: {guessCounter}");
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
