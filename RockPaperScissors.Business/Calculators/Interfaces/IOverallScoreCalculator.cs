using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business.Calculators.Interfaces
{
    public interface IOverallScoreCalculator
    {
        Result CalculateOverallWinner(IPlayer player1, IPlayer player2);
        bool HasAPlayerWon(int bestOf, IPlayer player1, IPlayer player2);
    }
}
