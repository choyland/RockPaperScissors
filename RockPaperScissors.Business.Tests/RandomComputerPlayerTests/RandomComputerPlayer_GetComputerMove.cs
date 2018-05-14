using Moq;
using NUnit.Framework;
using RockPaperScissors.Business.Model;
using RockPaperScissors.Business.MoveGenerators.Interfaces;

namespace RockPaperScissors.Business.Tests.RandomComputerPlayerTests
{
    [TestFixture]
    public class RandomComputerPlayer_GetComputerMove
    {
        [Test]
        public void RandomMoveGeneratorIsCalledOnceWhenGettingComputerMove()
        {
            // Arrange
            var mockRandomMoveGenerator = new Mock<IRandomMoveGenerator>();
            var randomComputerPlayer = new RandomComputerPlayer(mockRandomMoveGenerator.Object);

            //Act
            randomComputerPlayer.GetComputerMove();

            // Assert
            mockRandomMoveGenerator.Verify(m => m.GenerateRandomMove(), Times.Once);
        }
    }
}
