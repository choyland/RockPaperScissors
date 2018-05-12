using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.Calculators.Interfaces
{
    public interface IRoundCalculator
    {
        Result CalculateRoundResult(GameMove player1Move, GameMove player2Move);
    }
}
