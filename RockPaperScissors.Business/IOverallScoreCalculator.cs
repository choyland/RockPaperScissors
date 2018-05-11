using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business
{
    public interface IOverallScoreCalculator
    {
        Result CalculateOverallWinner(IPlayer player1, IPlayer player2);
        bool HasAPlayerWon(int bestOf, IPlayer player1, IPlayer player2);
    }

    public class OverallScoreCalculator : IOverallScoreCalculator
    {
        public Result CalculateOverallWinner(IPlayer player1, IPlayer player2)
        {
            if (player1.Wins == player2.Wins) return Result.Draw;

            return player1.Wins > player2.Wins ? Result.Player1Wins : Result.Player2Wins;
        }

        public bool HasAPlayerWon(int bestOf, IPlayer player1, IPlayer player2)
        {
            var requiredScoreToWin = (double) bestOf / 2;
            return player1.Wins > requiredScoreToWin || player2.Wins > requiredScoreToWin;
        }
    }
}
