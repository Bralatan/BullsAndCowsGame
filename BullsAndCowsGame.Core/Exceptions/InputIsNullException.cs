namespace BullsAndCowsGame.Core.Exceptions
{
    public class InputIsNullException : Exception
    {
        public InputIsNullException()
        {
        }

        public InputIsNullException(int riddleLength) : base($"Your guess is NULL. Please enter your guess with length - {riddleLength}")
        {
        }

        public InputIsNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}