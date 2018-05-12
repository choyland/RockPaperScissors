using System.Linq;
using RockPaperScissors.Business.Calculators.Interfaces;
using RockPaperScissors.Business.DataProviders.Interfaces;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.Calculators
{
    public class RoundCalculator : IRoundCalculator
    {
        private readonly IGameMoveOutcomeDataProvider _gameMoveOutcomeDataProvider;

        public RoundCalculator(IGameMoveOutcomeDataProvider gameMoveOutcomeDataProvider)
        {
            _gameMoveOutcomeDataProvider = gameMoveOutcomeDataProvider;
        }

        public Result CalculateRoundResult(GameMove player1Move, GameMove player2Move)
        {
            if (player1Move == player2Move) return Result.Draw;

            var player1MoveOutcomes = _gameMoveOutcomeDataProvider.AllGameMoveOutcomes.FirstOrDefault(x => x.Move == player1Move);

            // if player 2 move is listed as beaten by player 1 move then player 1 wins. 
            // Otherwise we can assume that player 2 has won as we have already checked for a draw
            return player1MoveOutcomes.Beats.Contains(player2Move) ? Result.Player1Wins : Result.Player2Wins;
        }
    }
}