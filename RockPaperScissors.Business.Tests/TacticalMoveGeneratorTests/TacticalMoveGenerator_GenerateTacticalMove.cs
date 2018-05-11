using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RockPaperScissors.Business.DataProvider;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model;

namespace RockPaperScissors.Business.Tests.TacticalMoveGeneratorTests
{
    [TestFixture]
    public class TacticalMoveGenerator_GenerateTacticalMove
    {
        private TacticalMoveGenerator _tacticalMoveGenerator;
        private Mock<IGameMoveOutcomeDataProvider> _mockGameOutcomeDataProvider;

        [Test]
        public void ArgumentExceptionThrownWhenGameOutcomeIsNotAvailableForPreviousMove()
        {
            // Arrange
            _mockGameOutcomeDataProvider = new Mock<IGameMoveOutcomeDataProvider>();
            _mockGameOutcomeDataProvider.Setup(m => m.AllGameMoveOutcomes)
                .Returns(new Dictionary<GameMove, GameMoveOutcomes>());
            _tacticalMoveGenerator = new TacticalMoveGenerator(_mockGameOutcomeDataProvider.Object);

            // Assert
            Assert.Throws<ArgumentException>(() => _tacticalMoveGenerator.GenerateTacticalMove(GameMove.Paper));
        }

        [Test]
        public void ReturnedGameMoveWouldHaveBeatenPreviousGameMove()
        {
            // Arrange
            var paperGameMoveOutcomes = new GameMoveOutcomes
            {
                Beats = new List<GameMove> {GameMove.Rock},
                LosesTo = new List<GameMove> {GameMove.Scissors}
            };

            _mockGameOutcomeDataProvider = new Mock<IGameMoveOutcomeDataProvider>();
            _mockGameOutcomeDataProvider.Setup(m => m.AllGameMoveOutcomes)
                .Returns(new Dictionary<GameMove, GameMoveOutcomes>{{GameMove.Paper, paperGameMoveOutcomes } });
            _tacticalMoveGenerator = new TacticalMoveGenerator(_mockGameOutcomeDataProvider.Object);

            // Act
            var result = _tacticalMoveGenerator.GenerateTacticalMove(GameMove.Paper);

            // Assert
            Assert.Contains(result, paperGameMoveOutcomes.LosesTo);
        }
    }
}
