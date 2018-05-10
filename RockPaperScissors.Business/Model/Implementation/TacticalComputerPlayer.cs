using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business.Model.Implementation
{
    public class TacticalComputerPlayer : IComputerPlayer
    {
        private static GameMove? _previousMove = null;

        public int Wins { get; set; }
        public GameMove GetComputerMove()
        {
            throw new System.NotImplementedException();
        }
    }
}
