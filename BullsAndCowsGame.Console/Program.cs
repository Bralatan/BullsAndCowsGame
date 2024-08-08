using BullsAndCowsGame.Core;
using BullsAndCowsGame.Core.Config;
using BullsAndCowsGame.Core.Factories;
using BullsAndCowsGame.Core.Factories.Interfaces;
using BullsAndCowsGame.Core.Models.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        var config = ConfigLoader.LoadConfig("..\\..\\..\\..\\BullsAndCowsGame.Core\\Config\\config.json");

        IRiddleProvider riddleProvider = new RiddleProviderFactory(config.RiddleType, config.RiddleLength).CreateRiddleProvider();


        Game game = new Game(riddleProvider);

        while (true) 
        {
            Console.Write("Enter your guess: ");
            string guess = Console.ReadLine();

            try
            {
                GameResult gameResult = game.Play(guess);

                if (gameResult.IsFinished)
                {
                    Console.WriteLine("Congratulations! You've guessed the riddle!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Your guess: {gameResult.InputValue}, you find {gameResult.Cows} cows, you find {gameResult.Bulls} bulls");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
