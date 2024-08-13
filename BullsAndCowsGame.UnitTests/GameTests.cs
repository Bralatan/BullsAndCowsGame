using BullsAndCowsGame.Core;
using BullsAndCowsGame.Core.Config;
using BullsAndCowsGame.Core.Exceptions;
using BullsAndCowsGame.Core.Factories;
using BullsAndCowsGame.Core.Factories.Interfaces;
using BullsAndCowsGame.Core.Models;
using BullsAndCowsGame.Core.Models.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System.Text.RegularExpressions;

namespace BullsAndCowsGame.UnitTests
{
    public class GameTests
    {
        private Game _game;
        private IRiddleProvider _riddleProvider;
        public GameTests()
        {
            _riddleProvider = new RiddleProviderFactory("number", 4, "").CreateRiddleProvider();
            _game = new Game(_riddleProvider);
        }

        [Fact]
        public void ShouldGenerateRiddleTypeOfString()
        {
            Assert.IsType<string>(_game.Riddle);
        }

        [Fact]
        public void ShouldGenerateRiddleWithSpecificLength()
        {
            Assert.Equal(4, _game.Riddle.Length);
        }

        [Fact]
        public void ShouldThrowAnErrorIfGuessIsOutOfRange()
        {
            Assert.Throws<InputOutOfRangeException>(() => _game.Play("35"));
        }

        [Fact]
        public void ShouldThrowAnErrorIfGuessIsEmpty()
        {
            Assert.Throws<InputIsEmptyException>(() => _game.Play(""));
        }

        [Fact]
        public void ShouldThrowAnErrorIfGuessIsNull()
        {
            Assert.Throws<InputIsNullException>(() => _game.Play(null));
        }

        [Fact]
        public void ShouldReturnGameResultWithCountOfCowsAndBulls()
        {
            _game.Riddle = "1256";
            var gameResult = _game.Play("1265");

            Assert.False(gameResult.IsFinished);
            Assert.Equal(2, gameResult.Cows);
            Assert.Equal(2, gameResult.Bulls);
        }

        [Fact]
        public void ShouldReturnGameResultWithCountOfBullsAndCowsAndFinishTheGame()
        {
            _game.Riddle = "1234";
            var gameResult = _game.Play("1234");
            
            Assert.True(gameResult.IsFinished);
            Assert.Equal(_game.Riddle.Length, gameResult.InputValue.Length);
            Assert.Equal(_game.Riddle.Length, gameResult.Bulls);
        }

        [Fact]
        public void ShouldReturnRiddleWithNumbersIfRiddleTypeIsNumber()
        {
            string RiddleRegex = "^[0-9]{4}$";

            Assert.True(Regex.Match(_game.Riddle, RiddleRegex).Success, $"Riddle {_game.Riddle} does not match regex {RiddleRegex}");
        }

        [Fact]
        public void ShouldReturnRiddleWithLettersIfRiddleTypeIsString()
        {
            string RiddleRegex = "^[a-zA-Z]{4}$";

            var riddleProvider = new RiddleProviderFactory("string", 4, "").CreateRiddleProvider();
            var game = new Game(riddleProvider);

            Assert.True(Regex.Match(game.Riddle, RiddleRegex).Success, $"Riddle {game.Riddle} does not match regex {RiddleRegex}");
        }

        [Fact]
        public void ShouldReturnRiddleWithStringIfRiddleTypeIsRealWord()
        {
            string RiddleRegex = "^[a-zA-Z]{4}$";
            string connectionString = "Data Source=(localdb)\\URLessDB;Initial Catalog=BullsAndCowsGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            
            var riddleProvider = new RiddleProviderFactory("realWord", 4, connectionString).CreateRiddleProvider();
            var game = new Game(riddleProvider);

            Assert.True(Regex.Match(game.Riddle, RiddleRegex).Success, $"Riddle {game.Riddle} does not match regex {RiddleRegex}");
        }

        [Fact]
        public void ShouldReturnStringRiddleProviderIfRiddleTypeIsString()
        {
            var riddleProvider = new RiddleProviderFactory("string", 4, "").CreateRiddleProvider();

            Assert.IsType<StringRiddleProvider>(riddleProvider);
        }

        [Fact]
        public void ShouldReturnRealWordRiddleProviderIfRiddleTypeIsRealWord()
        {
            var riddleProvider = new RiddleProviderFactory("realWord", 4, "").CreateRiddleProvider();

            Assert.IsType<RealWordRiddleProvider>(riddleProvider);
        }
    }
}