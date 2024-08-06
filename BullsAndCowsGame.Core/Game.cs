
using BullsAndCowsGame.Core.Factories.Interfaces;
using BullsAndCowsGame.Core.Models.Interfaces;

namespace BullsAndCowsGame.Core
{
    public class Game
    {
        private string _riddle;
        private readonly IRiddleProviderFactory _riddleProviderFactory;

        public Game(IRiddleProviderFactory riddleProviderFactory)
        {
            _riddleProviderFactory = riddleProviderFactory;
        }

        public string SetValue()
        {
            IRiddleProvider riddleProvider = _riddleProviderFactory.CreateRiddleProvider();

            return _riddle = riddleProvider.GenerateRiddle();
        }

        public GameResult Play(string userInput)
        {
            return new GameResult { InputValue = userInput, Bulls = 2, Cows = 1 };
        }
    }
}