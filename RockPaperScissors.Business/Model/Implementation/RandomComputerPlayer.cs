using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business.Model.Implementation
{
    public class RandomComputerPlayer : IComputerPlayer
    {
        public int Wins { get; set; }
        
        public GameMove GetComputerMove()
        {
            return RandomMoveGenerator.GetRandomMove();
        }
    }
}
