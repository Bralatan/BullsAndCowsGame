namespace BullsAndCowsGame.Core.Exceptions
{
    public class InputIsEmptyException : BullsAndCowsGameException
    {
        public InputIsEmptyException()
        {
        }

        public InputIsEmptyException(int riddleLength) : base($"Your guess is empty. Please enter your guess with length - {riddleLength}")
        {
        }

        public InputIsEmptyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}