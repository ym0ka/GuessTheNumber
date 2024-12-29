using System.Collections.Generic;

namespace GuessTheNumber
{
    class Program
    {
        static bool hintsEnabled;
        static List<string> yesKeywords = new List<string>{"y","Y","yes","YES"};
        static List<string> noKeywords = new List<string>{"n","N","no","NO"};
        
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing ConfigManager...");
            ConfigManager configManager = new ConfigManager();
            // string test = configManager.GetValueBasedOnKey("maxAttempts");
            // Console.WriteLine($"Max attempts to find the random number: {test}");
            
            Console.WriteLine("Launching GuessTheNumber!");
            Console.WriteLine("Would you like to use hints for you game ? (Y/N)");
            
            string playerHintChoice = null;
            //This while block is necessary to avoid player entering random values about activating hints or not.
            while (string.IsNullOrWhiteSpace(playerHintChoice) || (!yesKeywords.Contains(playerHintChoice) && !noKeywords.Contains(playerHintChoice)))
            {
                playerHintChoice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playerHintChoice))
                {
                    Console.WriteLine("Choice cannot be empty! Try again.");
                }

                if (!yesKeywords.Contains(playerHintChoice) && !noKeywords.Contains(playerHintChoice))
                {
                    Console.WriteLine("You need to enter yes or no!");
                }
                
            }
            if (yesKeywords.Contains(playerHintChoice))
            {
                Console.WriteLine("Enabled hints.");
                hintsEnabled = true;
            }
            
            if (noKeywords.Contains(playerHintChoice))
            {
                Console.WriteLine("Disabled hints.");
                hintsEnabled = false;
            }
            
            Console.WriteLine("Launching game with following settings :");
            string maxAttempts = configManager.GetValueBasedOnKey("maxAttempts");
            string minGuessingNumber = configManager.GetValueBasedOnKey("minGuessingNumber");
            string maxGuessingNumber = configManager.GetValueBasedOnKey("maxGuessingNumber");
            Console.WriteLine($"{maxAttempts} attempts to find the number.\nThe number is between {minGuessingNumber} and {maxGuessingNumber}.");
            Game(int.Parse(minGuessingNumber), int.Parse(maxGuessingNumber), int.Parse(maxAttempts));
        }

        static void Game(int minGuessingNumber, int maxGuessingNumber, int maxAttempts)
        {
            Random random = new Random();
            int gameRandomNumber = random.Next(minGuessingNumber, maxGuessingNumber);
            int gameAttempts = maxAttempts;
            //Console.WriteLine($"DEBUG : The number is: {gameRandomNumber}");

            Console.WriteLine("Welcome to GuessTheNumber!\nTry to guess the random number.");
            if (hintsEnabled)
            {
                if (gameRandomNumber % 2 == 0)
                {
                    Console.WriteLine("[Hint] The number is even.");
                }
                else
                {
                    Console.WriteLine("[Hint] The number is odd.");
                }
            }
            while (gameAttempts > 0)
            {
                
                string playerGuess = Console.ReadLine();
                if (playerGuess == gameRandomNumber.ToString())
                {
                    Console.WriteLine("Congratulations, you guessed the random number!");
                    return;
                }
                if (int.Parse(playerGuess) < maxGuessingNumber && int.Parse(playerGuess) > minGuessingNumber)
                {
                    if (gameAttempts-- > 0)
                    {
                        Console.WriteLine($"Try again, one attempt consumed. ! Remaining {gameAttempts} attempts.");
                        if (hintsEnabled)
                        {
                            if (playerGuess != null && int.Parse(playerGuess) > gameRandomNumber)
                            {
                                Console.WriteLine("[Hint] The number is lower than your guess!");
                            }
                            else if (playerGuess != null && int.Parse(playerGuess) < gameRandomNumber)
                            {
                                Console.WriteLine("[Hint] The number is greater than your guess!");
                            }
                        }
                    }
                } else if (int.Parse(playerGuess) > maxGuessingNumber || int.Parse(playerGuess) < minGuessingNumber)
                {
                    Console.WriteLine($"You are out of bonds. Value must be between {minGuessingNumber} and {maxGuessingNumber}.");
                }
                if (gameAttempts == 0)
                {
                    Console.WriteLine("Game Over!");
                    return;
                }
            }
        }
    }
}
