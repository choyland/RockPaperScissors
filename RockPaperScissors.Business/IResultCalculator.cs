using RockPaperScissors.Business.DataProvider;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business
{
    public interface IResultCalculator
    {
        Result CalculateRoundResult(GameMove player1Move, GameMove player2Move);
    }

    public class ResultCalculator : IResultCalculator
    {
        private readonly IGameMoveOutcomeDataProvider _gameMoveOutcomeDataProvider;

        public ResultCalculator(IGameMoveOutcomeDataProvider gameMoveOutcomeDataProvider)
        {
            _gameMoveOutcomeDataProvider = gameMoveOutcomeDataProvider;
        }

        public Result CalculateRoundResult(GameMove player1Move, GameMove player2Move)
        {
            if (player1Move == player2Move) return Result.Draw;

            var outcomes = _gameMoveOutcomeDataProvider.AllGameMoveOutcomes[player1Move];

            // if player 2 move is listed as beaten by player 1 move then player 1 wins. 
            // Otherwise we can assume that player 2 has won as we have already checked for a draw
            return outcomes.Beats.Contains(player2Move) ? Result.Player1Wins : Result.Player2Wins;
        }
    }
}
