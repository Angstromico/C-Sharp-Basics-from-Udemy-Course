using System;
using System.Collections.Generic;
using System.Text;

namespace First_Steps
{
    internal class GuessNumberWhileLoop
    {
        public static void Run()
        {
            Random random = new Random();
            int numberToGuess = random.Next(1, 1001); // Random number between 1 and 1000
            int userGuess = 0;
            int tries = 0;
            Console.WriteLine("Welcome to the Guess the Number Game!");
            Console.WriteLine("I have selected a number between 1 and 1000. Try to guess it!");
            while (userGuess != numberToGuess)
            {
                Console.Write("Enter your guess: ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out userGuess))
                {
                    tries++;
                    if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else if (userGuess > numberToGuess)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You've guessed the number!");
                        Console.WriteLine("It took you {0} tries.", tries);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
