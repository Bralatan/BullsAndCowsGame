using BullsAndCowsGame.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCowsGame.Core.Models
{
    public class NumberRiddleProvider : IRiddleProvider
    {
        private int _length;

        public NumberRiddleProvider(int length)
        {
            _length = length;
        }

        public string GenerateRiddle()
        {
            var random = new Random();
            return new string(Enumerable.Repeat("0123456789", _length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
