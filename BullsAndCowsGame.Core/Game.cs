
using BullsAndCowsGame.Core.Exceptions;
using BullsAndCowsGame.Core.Factories.Interfaces;
using BullsAndCowsGame.Core.Models.Interfaces;

namespace BullsAndCowsGame.Core
{
    public class Game
    {
        public string Riddle { get; set; }
        private readonly IRiddleProvider _riddleProvider;
        private int _riddleLength;

        public Game(IRiddleProvider riddleProvider)
        {
            _riddleProvider = riddleProvider;
            Riddle = _riddleProvider.GenerateRiddle();
            _riddleLength = Riddle.Length;
        }

        public GameResult Play(string userInput)
        {

            if (userInput == "")
            {
                throw new InputIsEmptyException(_riddleLength);
            }

            if (userInput == null)
            {
                throw new InputIsNullException(_riddleLength);
            }

            if (userInput.Length != _riddleLength) 
            {
                throw new InputOutOfRangeException(userInput, _riddleLength);
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
                if (userInput[i] == Riddle[i])
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
                if (Riddle.Contains(userInput[i]) && userInput[i] != Riddle[i])
                {
                    count++;
                }
            }

            return count;
        }
    }
}