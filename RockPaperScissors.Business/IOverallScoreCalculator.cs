using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business
{
    public interface IOverallScoreCalculator
    {
        RoundResult CalculateOverallWinner(IPlayer player1, IPlayer player2);
        bool HasAPlayerWon(int bestOf, IPlayer player1, IPlayer player2);
    }

    public class OverallScoreCalculator : IOverallScoreCalculator
    {
        public RoundResult CalculateOverallWinner(IPlayer player1, IPlayer player2)
        {
            if (player1.Wins == player2.Wins) return RoundResult.Draw;

            return player1.Wins > player2.Wins ? RoundResult.Player1Wins : RoundResult.Player2Wins;
        }

        public bool HasAPlayerWon(int bestOf, IPlayer player1, IPlayer player2)
        {
            var requiredScoreToWin = (double) bestOf / 2;
            return player1.Wins > requiredScoreToWin || player2.Wins > requiredScoreToWin;
        }
    }
}
