using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.MoveGenerators.Interfaces
{
    public interface ITacticalMoveGenerator
    {
        GameMove GenerateTacticalMove(GameMove previousGameMove);
    }
}
