using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.MoveGenerators.Interfaces
{
    public interface IRandomMoveGenerator
    {
        GameMove GenerateRandomMove();
    }
}
