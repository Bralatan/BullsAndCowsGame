using BullsAndCowsGame.Core;
using BullsAndCowsGame.Core.Config;
using BullsAndCowsGame.Core.Factories;
using BullsAndCowsGame.Core.Factories.Interfaces;
using BullsAndCowsGame.UnitTests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System.Text.RegularExpressions;

namespace BullsAndCowsGame.UnitTests
{
    public class GameTests
    {
        //private readonly object _config = ConfigLoader.LoadConfig("config.json");
        private GameInteractorFake _gameInteractorFake;

        public GameTests() 
        {

        }

        [Fact]
        public void ShouldGenerateRiddleTypeOfString()
        {
            IRiddleProviderFactory riddleProviderFactory = new NumberRiddleProviderFactory(4);
            _gameInteractorFake = new GameInteractorFake(riddleProviderFactory);

            var result = _gameInteractorFake.SetValue();

            Assert.IsType<string>(result);
        }

        [Fact]
        public void ShouldGenerateRiddleWithSpecificLength()
        {
            IRiddleProviderFactory riddleProviderFactory = new NumberRiddleProviderFactory(4);
            _gameInteractorFake = new GameInteractorFake(riddleProviderFactory);

            var result = _gameInteractorFake.SetValue();

            Assert.Equal(4, result.Length);
        }
    }
}