using BullsAndCowsGame.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCowsGame.Core.Models
{
    public class StringRiddleProvider: IRiddleProvider
    {
        private int _length;

        public StringRiddleProvider(int length)
        {
            _length = length;
        }

        public string GenerateRiddle()
        {
            var random = new Random();
            return new string(Enumerable.Repeat("qwertyuiopasdfghjklzxcvbnm", _length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
