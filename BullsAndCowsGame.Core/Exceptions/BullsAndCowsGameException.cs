using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCowsGame.Core.Exceptions
{
    public class BullsAndCowsGameException: Exception
    {
        public BullsAndCowsGameException()
        {
        }

        public BullsAndCowsGameException(string riddleLength) : base(riddleLength)
        {
            RiddleLength = riddleLength;
            IsError = true;
        }

        public BullsAndCowsGameException(string? userInput, string riddleLength) : base($"{userInput}, {riddleLength}")
        {
            UserInput = userInput;
            RiddleLength = riddleLength;
            IsError = true;
        }

        public BullsAndCowsGameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public string UserInput { get; }
        public string RiddleLength { get; }
        public bool IsError { get; }
    }
}
