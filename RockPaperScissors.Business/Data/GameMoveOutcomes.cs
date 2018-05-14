using System.Collections.Generic;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.Data
{
    public class GameMoveOutcomes
    {
        public GameMove Move { get; set; }
        public List<GameMove> Beats { get; set; }
    }
}
