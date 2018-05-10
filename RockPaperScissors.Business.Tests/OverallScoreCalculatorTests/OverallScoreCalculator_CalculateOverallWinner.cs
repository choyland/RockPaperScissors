using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business.Tests.OverallScoreCalculatorTests
{
    [TestFixture]
    public class OverallScoreCalculator_CalculateOverallWinner
    {
        private readonly OverallScoreCalculator _overallScoreCalculator;

        public OverallScoreCalculator_CalculateOverallWinner()
        {
            _overallScoreCalculator = new OverallScoreCalculator();
        }

        [Test]
        public void ReturnPlayer1WinsWhenPlayer1HasHigherScore()
        {
            // Arrange
            var player1 = new Mock<IPlayer>();
            player1.Setup(m => m.Wins).Returns(2);

            var player2 = new Mock<IPlayer>();
            player2.Setup(m => m.Wins).Returns(1);

            // Act
            var result = _overallScoreCalculator.CalculateOverallWinner(player1.Object, player2.Object);

            // Assert
            Assert.AreEqual(RoundResult.Player1Wins, result);
        }

        [Test]
        public void ReturnPlayer2WinsWhenPlayer2HasHigherScore()
        {
            // Arrange
            var player1 = new Mock<IPlayer>();
            player1.Setup(m => m.Wins).Returns(1);

            var player2 = new Mock<IPlayer>();
            player2.Setup(m => m.Wins).Returns(2);

            // Act
            var result = _overallScoreCalculator.CalculateOverallWinner(player1.Object, player2.Object);

            // Assert
            Assert.AreEqual(RoundResult.Player2Wins, result);
        }

        [Test]
        public void ReturnDrawWhenPlayersHaveEqualScore()
        {
            // Arrange
            var player1 = new Mock<IPlayer>();
            player1.Setup(m => m.Wins).Returns(1);

            var player2 = new Mock<IPlayer>();
            player2.Setup(m => m.Wins).Returns(1);

            // Act
            var result = _overallScoreCalculator.CalculateOverallWinner(player1.Object, player2.Object);

            // Assert
            Assert.AreEqual(RoundResult.Draw, result);
        }
    }
}
