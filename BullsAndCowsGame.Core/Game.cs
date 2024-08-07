
using BullsAndCowsGame.Core.Exceptions;
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

        public GameResult Play(string userInput, int riddleLength)
        {

            if (userInput == "")
            {
                return new GameResult
                {
                    Error = new InputIsEmptyException(riddleLength)
                };
            }

            if (userInput == null)
            {
                return new GameResult
                {
                    Error = new InputIsNullException(riddleLength)
                };
            }

            if (userInput.Length != riddleLength) 
            {
                return new GameResult
                {
                    Error = new InputOutOfRangeException(userInput, riddleLength)
                };
            }

            return new GameResult 
            { 
                InputValue = userInput, 
                Bulls = SearchAndCountBulls(userInput), 
                Cows = SearchAndCountCows(userInput)
            };
        }

        private int SearchAndCountBulls(string userInput) 
        {
            int count = 0;

            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] == _riddle[i])
                {
                    count++;
                }
            }

            return count;
        }

        private int SearchAndCountCows(string userInput)
        {
            int count = 0;

            for (int i = 0; i < userInput.Length; i++)
            {
                if (_riddle.Contains(userInput[i]) && userInput[i] != _riddle[i])
                {
                    count++;
                }
            }

            return count;
        }
    }
}