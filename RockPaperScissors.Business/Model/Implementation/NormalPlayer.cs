using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business.Model.Implementation
{
    public class NormalPlayer : INormalPlayer
    {
        public int Wins { get; set; }
        public GameMove Move { get; set; }
    }
}
