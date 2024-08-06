using BullsAndCowsGame.Core.Factories.Interfaces;
using BullsAndCowsGame.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCowsGame.UnitTests.Helpers
{
    public class GameInteractorFake
    {
        private string _riddle;
        private readonly IRiddleProviderFactory _riddleProviderFactory;

        public GameInteractorFake(IRiddleProviderFactory riddleProviderFactory) 
        {
            _riddleProviderFactory = riddleProviderFactory;
        }

        public string SetValue()
        {
            IRiddleProvider riddleProvider = _riddleProviderFactory.CreateRiddleProvider();

            return _riddle = riddleProvider.GenerateRiddle();
        }
    }
}
