using System;
using System.Linq;
using RockPaperScissors.Business.DataProvider;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business
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
            if (!_gameMoveOutcomeDataProvider.AllGameMoveOutcomes.ContainsKey(previousGameMove))
                throw new ArgumentException($"Can't find game outcome record for {previousGameMove.ToString()}");

            // Get the game moves that would have beaten the previous move, randomly order them and select the first
            return _gameMoveOutcomeDataProvider.AllGameMoveOutcomes[previousGameMove].LosesTo.OrderBy(g => Guid.NewGuid())
                .First();
        }
    }
}
