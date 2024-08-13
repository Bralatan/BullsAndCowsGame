using BullsAndCowsGame.Core.Exceptions;

namespace BullsAndCowsGame.Core
{
    public class GameResult
    {
        public string? InputValue { get; set; }
        public int Bulls { get; set; }
        public int Cows { get; set; }
        public bool IsFinished 
        {
            get
            {
                return Bulls == InputValue.Length;
            }
        }
    }
}