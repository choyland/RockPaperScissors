using System.Collections.Generic;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model;

namespace RockPaperScissors.Business.DataProvider
{
    public interface IGameMoveOutcomeDataProvider
    {
        Dictionary<GameMove, GameMoveOutcomes> AllGameMoveOutcomes { get; }
    }

    public class GameMoveOutcomeDataProvider : IGameMoveOutcomeDataProvider
    {
        public Dictionary<GameMove, GameMoveOutcomes> AllGameMoveOutcomes { get; }

        public GameMoveOutcomeDataProvider()
        {
            AllGameMoveOutcomes = new Dictionary<GameMove, GameMoveOutcomes>
            {
                {
                    GameMove.Paper,
                    new GameMoveOutcomes
                    {
                        Beats = new List<GameMove> {GameMove.Rock},
                        LosesTo = new List<GameMove> {GameMove.Scissors}
                    }
                },
                {
                    GameMove.Scissors,
                    new GameMoveOutcomes
                    {
                        Beats = new List<GameMove> {GameMove.Paper},
                        LosesTo = new List<GameMove> {GameMove.Rock}
                    }
                },
                {
                    GameMove.Rock,
                    new GameMoveOutcomes
                    {
                        Beats = new List<GameMove> {GameMove.Scissors},
                        LosesTo = new List<GameMove> {GameMove.Paper}
                    }
                }
            };

        }
        
    }
}
