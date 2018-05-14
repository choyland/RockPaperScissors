using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RockPaperScissors.Business.Calculators;
using RockPaperScissors.Business.Data;
using RockPaperScissors.Business.Data.Interfaces;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.Tests.RoundCalculatorTests
{
    [TestFixture]
    public class RoundCalculator_CalculateRoundResult
    {
        public void Player1MoveEqualsPlayer2MoveADrawIsReturned()
        {
            // Arrange
            const GameMove player1Move = GameMove.Rock;
            const GameMove player2Move = player1Move;

            var mockgameMoveOutcomeDataProvider = new Mock<IGameMoveOutcomeDataProvider>();

            var roundCalculator = new RoundCalculator(mockgameMoveOutcomeDataProvider.Object);

            // Act
            var result = roundCalculator.CalculateRoundResult(player1Move, player2Move);

            // Assert
            Assert.AreEqual(Result.Draw, result);
        }

        public void Player1MoveBeatsPlayer2MovePlayer1Wins()
        {
            // Arrange
            const GameMove player1Move = GameMove.Rock;
            const GameMove player2Move = GameMove.Scissors;

            var mockgameMoveOutcomeDataProvider = new Mock<IGameMoveOutcomeDataProvider>();
            var gameMoveOutcomes = new List<GameMoveOutcomes>{new GameMoveOutcomes{Move = player1Move, Beats = new List<GameMove>{player2Move}}};
            mockgameMoveOutcomeDataProvider.Setup(m => m.AllGameMoveOutcomes).Returns(gameMoveOutcomes);

            var roundCalculator = new RoundCalculator(mockgameMoveOutcomeDataProvider.Object);

            // Act
            var result = roundCalculator.CalculateRoundResult(player1Move, player2Move);

            // Assert
            Assert.AreEqual(Result.Player1Wins, result);
        }

        public void Player1MoveDoesNotBeatOrDrawWithPlayer2MovePlayer2Wins()
        {
            // Arrange
            const GameMove player1Move = GameMove.Rock;
            const GameMove player2Move = GameMove.Paper;

            var mockgameMoveOutcomeDataProvider = new Mock<IGameMoveOutcomeDataProvider>();
            var gameMoveOutcomes = new List<GameMoveOutcomes> { new GameMoveOutcomes { Move = player1Move, Beats = new List<GameMove> { GameMove.Scissors } } };
            mockgameMoveOutcomeDataProvider.Setup(m => m.AllGameMoveOutcomes).Returns(gameMoveOutcomes);

            var roundCalculator = new RoundCalculator(mockgameMoveOutcomeDataProvider.Object);

            // Act
            var result = roundCalculator.CalculateRoundResult(player1Move, player2Move);

            // Assert
            Assert.AreEqual(Result.Player2Wins, result);
        }
    }
}
