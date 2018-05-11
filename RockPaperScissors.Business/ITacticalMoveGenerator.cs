using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business
{
    public interface ITacticalMoveGenerator
    {
        GameMove GenerateTacticalMove(GameMove previousGameMove);
    }
}
