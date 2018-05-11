using Moq;
using NUnit.Framework;
using RockPaperScissors.Business.Model.Implementation;

namespace RockPaperScissors.Business.Tests.RandomComputerPlayerTests
{
    [TestFixture]
    public class RandomComputerPlayer_GetComputerMove
    {
        private RandomComputerPlayer _randomComputerPlayer;

        [Test]
        public void RandomMoveGeneratorIsCalledOnceWhenGettingComputerMove()
        {
            // Arrange
            var mockRandomMoveGenerator = new Mock<IRandomMoveGenerator>();
            _randomComputerPlayer = new RandomComputerPlayer(mockRandomMoveGenerator.Object);

            //Act
            _randomComputerPlayer.GetComputerMove();

            // Assert
            mockRandomMoveGenerator.Verify(m => m.GenerateRandomMove(), Times.Once);
        }
    }
}
