namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing ConfigManager...");
            ConfigManager configManager = new ConfigManager();

            string maxAttempts = configManager.GetValueBasedOnKey("maxAttempts");
            Console.WriteLine($"Max attempts to find the random number: {maxAttempts}");
        }
    }
}
