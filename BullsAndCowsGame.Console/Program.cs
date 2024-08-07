using BullsAndCowsGame.Core;
using BullsAndCowsGame.Core.Config;
using BullsAndCowsGame.Core.Factories;
using BullsAndCowsGame.Core.Factories.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        var config = ConfigLoader.LoadConfig("..\\..\\..\\..\\BullsAndCowsGame.Core\\Config\\config.json");

        IRiddleProviderFactory riddleProviderFactory;

        if (config.riddleType.Equals("number", StringComparison.OrdinalIgnoreCase))
        {
            riddleProviderFactory = new NumberRiddleProviderFactory(config.riddleLength);
        }
        else
        {
            throw new InvalidOperationException("Invalid type of riddle.");
        }

        Game game = new Game(riddleProviderFactory);
        game.SetValue();

        while (true) 
        {
            Console.Write("Enter your guess: ");
            string guess = Console.ReadLine();

            GameResult gameResult = game.Play(guess, config.riddleLength);

            if (gameResult.Error != null && gameResult.Error.IsError)
            {
                Console.WriteLine(gameResult.Error.Message);
            }
            else if (gameResult.IsFinished) 
            {
                Console.WriteLine("Congratulations! You've guessed the riddle!");
                break;
            } 
            else
            {
                Console.WriteLine($"Your guess: {gameResult.InputValue}, you find {gameResult.Cows} cows, you find {gameResult.Bulls} bulls");
            }
        }
    }
}
