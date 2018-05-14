using Moq;
using NUnit.Framework;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model;
using RockPaperScissors.Business.MoveGenerators.Interfaces;

namespace RockPaperScissors.Business.Tests.TacticalComputerPlayerTests
{
    [TestFixture]
    public class TacticalComputerPlayer_GetComputerMove
    {
        [Test]
        public void WhenPreviousMoveIsNullRandomGameMoveGeneratorShouldBeCalledOnce()
        {
            // Arrange
            const GameMove expectedGameMove = GameMove.Paper;

            var randomMoveGeneratorMock = new Mock<IRandomMoveGenerator>();
            randomMoveGeneratorMock.Setup(m => m.GenerateRandomMove()).Returns(expectedGameMove);

            var tacticalMoveGeneratorMock = new Mock<ITacticalMoveGenerator>();
            tacticalMoveGeneratorMock.Setup(m => m.GenerateTacticalMove(It.IsAny<GameMove>())).Returns(GameMove.Rock);

            var tacticalComputerPlayer =
                new TacticalComputerPlayer(tacticalMoveGeneratorMock.Object, randomMoveGeneratorMock.Object)
                {
                    PreviousMove = null
                };

            // Act
            tacticalComputerPlayer.GetComputerMove();

            // Assert
            randomMoveGeneratorMock.Verify(m => m.GenerateRandomMove(), Times.Once);
        }

        [Test]
        public void WhenPreviousMoveIsNullTacticalGameMoveGeneratorShouldNeverBeCalled()
        {
            // Arrange
            var randomMoveGeneratorMock = new Mock<IRandomMoveGenerator>();
            var tacticalMoveGeneratorMock = new Mock<ITacticalMoveGenerator>();
            
            var tacticalComputerPlayer =
                new TacticalComputerPlayer(tacticalMoveGeneratorMock.Object, randomMoveGeneratorMock.Object)
                {
                    PreviousMove = null
                };

            // Act
            tacticalComputerPlayer.GetComputerMove();

            // Assert
            tacticalMoveGeneratorMock.Verify(m => m.GenerateTacticalMove(It.IsAny<GameMove>()), Times.Never);
        }

        [Test]
        public void WhenPreviousMoveIsNotNullTacticalGameMoveGeneratorShouldBeCalledOnceWithTheCorrectPreviousMove()
        {
            // Arrange
            const GameMove previousMove = GameMove.Rock;

            var randomMoveGeneratorMock = new Mock<IRandomMoveGenerator>();
            var tacticalMoveGeneratorMock = new Mock<ITacticalMoveGenerator>();

            var tacticalComputerPlayer =
                new TacticalComputerPlayer(tacticalMoveGeneratorMock.Object, randomMoveGeneratorMock.Object)
                {
                    PreviousMove = previousMove
                };

            // Act
            tacticalComputerPlayer.GetComputerMove();

            // Assert
            tacticalMoveGeneratorMock.Verify(m => m.GenerateTacticalMove(It.Is<GameMove>(x => x == previousMove)), Times.Once);
        }

        [Test]
        public void WhenPreviousMoveIsNotNullRandomGameMoveGeneratorShouldNeverBeCalled()
        {
            // Arrange
            const GameMove previousMove = GameMove.Rock;

            var randomMoveGeneratorMock = new Mock<IRandomMoveGenerator>();
            var tacticalMoveGeneratorMock = new Mock<ITacticalMoveGenerator>();

            var tacticalComputerPlayer =
                new TacticalComputerPlayer(tacticalMoveGeneratorMock.Object, randomMoveGeneratorMock.Object)
                {
                    PreviousMove = previousMove
                };

            // Act
            tacticalComputerPlayer.GetComputerMove();

            // Assert
            randomMoveGeneratorMock.Verify(m => m.GenerateRandomMove(), Times.Never);
        }
    }
}
