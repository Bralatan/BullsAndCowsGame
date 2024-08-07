namespace BullsAndCowsGame.Core.Exceptions
{
    [Serializable]
    public class InputOutOfRangeException : BullsAndCowsGameException
    {
        public InputOutOfRangeException()
        {
        }

        public InputOutOfRangeException(string? userInput, int riddleLength) : base($"Your guess '{userInput}' is out of range. Please enter guess with length - {riddleLength}")
        {
        }

        public InputOutOfRangeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}