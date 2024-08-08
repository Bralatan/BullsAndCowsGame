using BullsAndCowsGame.Core.Factories.Interfaces;
using BullsAndCowsGame.Core.Models;
using BullsAndCowsGame.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCowsGame.Core.Factories
{
    public class RiddleProviderFactory : IRiddleProviderFactory
    {
        private int _length;
        private string _type;

        public RiddleProviderFactory(string type, int length)
        {
            _type = type;
            _length = length;
        }

        public IRiddleProvider CreateRiddleProvider()
        {
            return _type switch
            {
                "number" => new NumberRiddleProvider(_length),
                "string" => new StringRiddleProvider(_length),
                _ => throw new ArgumentException()
            };
        }
    }
}
