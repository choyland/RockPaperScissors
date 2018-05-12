using System.Collections.Generic;
using RockPaperScissors.Business.Model;

namespace RockPaperScissors.Business.DataProviders.Interfaces
{
    public interface IGameMoveOutcomeDataProvider
    {
        List<GameMoveOutcomes> AllGameMoveOutcomes { get; }
    }
}
