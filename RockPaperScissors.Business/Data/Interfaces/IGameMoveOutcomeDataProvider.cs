using System.Collections.Generic;

namespace RockPaperScissors.Business.Data.Interfaces
{
    public interface IGameMoveOutcomeDataProvider
    {
        List<GameMoveOutcomes> AllGameMoveOutcomes { get; }
    }
}
