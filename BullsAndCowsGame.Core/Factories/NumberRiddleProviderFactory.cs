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
    public class NumberRiddleProviderFactory : IRiddleProviderFactory
    {
        private int _length;

        public NumberRiddleProviderFactory(int length)
        {
            _length = length;
        }

        public IRiddleProvider CreateRiddleProvider()
        {
            return new NumberRiddleProvider(_length);
        }
    }
}
