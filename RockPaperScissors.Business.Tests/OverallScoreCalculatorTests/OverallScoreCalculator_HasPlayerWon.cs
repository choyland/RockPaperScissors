using Moq;
using NUnit.Framework;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business.Tests.OverallScoreCalculatorTests
{
    [TestFixture]
    public class OverallScoreCalculator_HasPlayerWon
    {
        private readonly OverallScoreCalculator _overallScoreCalculator;

        public OverallScoreCalculator_HasPlayerWon()
        {
            _overallScoreCalculator = new OverallScoreCalculator();
        }

        [Test]
        public void ReturnFalseGivenPlayersYetToAchieveWinningScore()
        {
            // Arrange
            var player1 = new Mock<IPlayer>();
            player1.Setup(m => m.Wins).Returns(1);
            
            var player2 = new Mock<IPlayer>();
            player2.Setup(m => m.Wins).Returns(1);

            const int bestOf = 3;

            //Act
            var result = _overallScoreCalculator.HasAPlayerWon(bestOf, player1.Object, player2.Object);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnTrueGivenPlayer1HasAchivedeWinningScore()
        {
            // Arrange
            var player1 = new Mock<IPlayer>();
            player1.Setup(m => m.Wins).Returns(2);

            var player2 = new Mock<IPlayer>();
            player2.Setup(m => m.Wins).Returns(1);

            const int bestOf = 3;

            //Act
            var result = _overallScoreCalculator.HasAPlayerWon(bestOf, player1.Object, player2.Object);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnTrueGivenPlayer2HasAchivedeWinningScore()
        {
            // Arrange
            var player1 = new Mock<IPlayer>();
            player1.Setup(m => m.Wins).Returns(1);

            var player2 = new Mock<IPlayer>();
            player2.Setup(m => m.Wins).Returns(2);

            const int bestOf = 3;

            //Act
            var result = _overallScoreCalculator.HasAPlayerWon(bestOf, player1.Object, player2.Object);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
