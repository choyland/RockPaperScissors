using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RockPaperScissors.Business.Data;
using RockPaperScissors.Business.Data.Interfaces;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model;
using RockPaperScissors.Business.MoveGenerators;

namespace RockPaperScissors.Business.Tests.TacticalMoveGeneratorTests
{
    [TestFixture]
    public class TacticalMoveGenerator_GenerateTacticalMove
    {
        private TacticalMoveGenerator _tacticalMoveGenerator;
        private Mock<IGameMoveOutcomeDataProvider> _mockGameOutcomeDataProvider;

        [Test]
        public void ReturnedGameMoveWouldHaveBeatenPreviousGameMove()
        {
            // Arrange
            var previousMove = GameMove.Paper;
            var moveWhichBeatsPreviousMove = GameMove.Scissors;
            
            var gameMoveOutcome = new GameMoveOutcomes
            {
                Move = moveWhichBeatsPreviousMove,
                Beats = new List<GameMove> { previousMove }
            };

            _mockGameOutcomeDataProvider = new Mock<IGameMoveOutcomeDataProvider>();
            _mockGameOutcomeDataProvider.Setup(m => m.AllGameMoveOutcomes)
                .Returns(new List<GameMoveOutcomes>{gameMoveOutcome});
            _tacticalMoveGenerator = new TacticalMoveGenerator(_mockGameOutcomeDataProvider.Object);

            // Act
            var result = _tacticalMoveGenerator.GenerateTacticalMove(previousMove);

            // Assert
            Assert.AreEqual(moveWhichBeatsPreviousMove, result);
        }
    }
}
