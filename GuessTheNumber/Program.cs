﻿using System.Security.Cryptography;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing ConfigManager...");
            ConfigManager configManager = new ConfigManager();

            // string test = configManager.GetValueBasedOnKey("maxAttempts");
            // Console.WriteLine($"Max attempts to find the random number: {test}");
            
            Console.WriteLine("Welcome to GuessTheNumber!");
            Console.WriteLine("Would you like to use hints for you game ? (Y/N)");
            switch (Console.ReadLine())
            {
                case "Y":
                case "y":
                case "YES":
                case "yes":
                    Console.WriteLine("Hints are currently WIP. Stopping program.");
                    break;
                case "N":
                case "n":
                case "NO":
                case "no":
                    Console.WriteLine("Launching game with following settings :");
                    string maxAttempts = configManager.GetValueBasedOnKey("maxAttempts");
                    string minGuessingNumber = configManager.GetValueBasedOnKey("minGuessingNumber");
                    string maxGuessingNumber = configManager.GetValueBasedOnKey("maxGuessingNumber");
                    Console.WriteLine($"{maxAttempts} attempts to find the number.\nThe number is between {minGuessingNumber} and {maxGuessingNumber}.");
                    Game(int.Parse(minGuessingNumber), int.Parse(maxGuessingNumber), int.Parse(maxAttempts));
                    break;
            }
        }

        static void Game(int minGuessingNumber, int maxGuessingNumber, int maxAttempts)
        {
            Random random = new Random();
            int gameRandomNumber = random.Next(minGuessingNumber, maxGuessingNumber);
            int gameAttempts = maxAttempts;
            //Console.WriteLine($"DEBUG : The number is: {gameRandomNumber}");

            while (gameAttempts > 0)
            {
                Console.WriteLine("Welcome to GuessTheNumber!\nTry to guess the random number.");
                if (Console.ReadLine() == gameRandomNumber.ToString())
                {
                    Console.WriteLine("Congratulations, you guessed the random number!");
                    return;
                }
                gameAttempts--;
                if (gameAttempts > 0)
                {
                    Console.WriteLine($"Try again, one attempt consumed. ! Remaining {gameAttempts} attempts.");
                }

                if (gameAttempts == 0)
                {
                    Console.WriteLine("Game Over!");
                }
            }
        }
    }
}
