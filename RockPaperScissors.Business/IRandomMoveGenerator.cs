using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business
{
    public interface IRandomMoveGenerator
    {
        GameMove GenerateRandomMove();
    }
}
