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
        private Game _game;
        public GameTests() 
        {

        }

        [Fact]
        public void ShouldGenerateRiddleTypeOfString()
        {
            IRiddleProviderFactory riddleProviderFactory = new NumberRiddleProviderFactory(4);
            _game = new Game(riddleProviderFactory);

            var riddle = _game.SetValue();

            Assert.IsType<string>(riddle);
        }

        [Fact]
        public void ShouldGenerateRiddleWithSpecificLength()
        {
            IRiddleProviderFactory riddleProviderFactory = new NumberRiddleProviderFactory(4);
            _game = new Game(riddleProviderFactory);

            var riddle = _game.SetValue();

            Assert.Equal(4, riddle.Length);
        }

        [Fact]
        public void ShouldReturnAnErrorIfGuessIsOutOfRange()
        {
            IRiddleProviderFactory riddleProviderFactory = new NumberRiddleProviderFactory(4);
            _game = new Game(riddleProviderFactory);

            var riddle = _game.SetValue();
            var result = _game.Play("35", 4);

            Assert.True(result.Error.IsError);
            Assert.Contains(result.Error.Message, "Your guess '35' is out of range. Please enter guess with length - 4");
        }

        [Fact]
        public void ShouldReturnAnErrorIfGuessIsEmpty()
        {
            IRiddleProviderFactory riddleProviderFactory = new NumberRiddleProviderFactory(4);
            _game = new Game(riddleProviderFactory);

            var riddle = _game.SetValue();
            var result = _game.Play("", 4);

            Assert.True(result.Error.IsError);
            Assert.Contains(result.Error.Message, "Your guess is empty. Please enter your guess with length - 4");
        }

        [Fact]
        public void ShouldReturnAnErrorIfGuessIsNull()
        {
            IRiddleProviderFactory riddleProviderFactory = new NumberRiddleProviderFactory(4);
            _game = new Game(riddleProviderFactory);

            var riddle = _game.SetValue();
            var result = _game.Play(null, 4);

            Assert.True(result.Error.IsError);
            Assert.Contains(result.Error.Message, "Your guess is NULL. Please enter your guess with length - 4");
        }
    }
}