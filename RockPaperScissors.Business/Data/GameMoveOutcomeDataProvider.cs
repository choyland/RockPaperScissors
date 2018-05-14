using System.Collections.Generic;
using RockPaperScissors.Business.Data.Interfaces;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.Data
{
    public class GameMoveOutcomeDataProvider : IGameMoveOutcomeDataProvider
    {
        public List<GameMoveOutcomes> AllGameMoveOutcomes { get; }

        public GameMoveOutcomeDataProvider()
        {
            AllGameMoveOutcomes = new List<GameMoveOutcomes>()
            {
                new GameMoveOutcomes
                {
                    Move = GameMove.Paper,
                    Beats = new List<GameMove> {GameMove.Rock}
                },
                new GameMoveOutcomes
                {
                    Move = GameMove.Scissors,
                    Beats = new List<GameMove> {GameMove.Paper},
                },
                new GameMoveOutcomes
                {
                    Move = GameMove.Rock,
                    Beats = new List<GameMove> {GameMove.Scissors}
                }
            };
        }
    }
}