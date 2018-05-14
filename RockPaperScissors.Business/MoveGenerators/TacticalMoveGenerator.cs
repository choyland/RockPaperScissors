using System;
using System.Linq;
using RockPaperScissors.Business.Data.Interfaces;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.MoveGenerators.Interfaces;

namespace RockPaperScissors.Business.MoveGenerators
{
    public class TacticalMoveGenerator : ITacticalMoveGenerator
    {
        private readonly IGameMoveOutcomeDataProvider _gameMoveOutcomeDataProvider;

        public TacticalMoveGenerator(IGameMoveOutcomeDataProvider gameMoveOutcomeDataProvider)
        {
            _gameMoveOutcomeDataProvider = gameMoveOutcomeDataProvider;
        }

        public GameMove GenerateTacticalMove(GameMove previousGameMove)
        {
            // Get the game moves that would have beaten the previous move, randomly order them and select the first
            return _gameMoveOutcomeDataProvider.AllGameMoveOutcomes.Where(x => x.Beats.Contains(previousGameMove)).Select(xx => xx.Move)
                .OrderBy(xxx => Guid.NewGuid()).First();
        }
    }
}
