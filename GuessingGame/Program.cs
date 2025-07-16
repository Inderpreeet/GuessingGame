using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int answer = rnd.Next(1, 101);
        List<Guess> guesses = new List<Guess>();
        int userGuess = 0;

        Console.WriteLine("Guess a number between 1 and 100:");

        do
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine(); // Removed duplicate declaration

            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out userGuess))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            int index = guesses.FindIndex(g => g.UserGuess == userGuess);
            if (index != -1)
            {
                int turnsAgo = guesses.Count - index;
                Console.WriteLine($"You guessed this number {turnsAgo} turn(s) ago!");
            }

            guesses.Add(new Guess(userGuess));

            if (userGuess < answer)
                Console.WriteLine("Too low, try again.");
            else if (userGuess > answer)
                Console.WriteLine("Too high, try again.");

        } while (userGuess != answer);

        Console.WriteLine($"You Won! The answer was {answer}.");
    }
}
