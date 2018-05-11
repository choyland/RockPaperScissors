using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business.Model.Implementation
{
    public class RandomComputerPlayer : IComputerPlayer
    {
        public int Wins { get; set; }

        private readonly IRandomMoveGenerator _randomMoveGenerator;

        public RandomComputerPlayer(IRandomMoveGenerator randomMoveGenerator)
        {
            _randomMoveGenerator = randomMoveGenerator;
        }

        public GameMove GetComputerMove()
        {
            return _randomMoveGenerator.GenerateRandomMove();
        }
    }
}
