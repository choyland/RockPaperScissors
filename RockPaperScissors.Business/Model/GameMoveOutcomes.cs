using System.Collections.Generic;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.Model
{
    public class GameMoveOutcomes
    {
        public GameMove Move { get; set; }
        public List<GameMove> Beats { get; set; }
    }
}
