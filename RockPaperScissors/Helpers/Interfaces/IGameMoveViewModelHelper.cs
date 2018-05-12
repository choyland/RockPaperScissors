using System.Collections.Generic;
using RockPaperScissors.ViewModels;

namespace RockPaperScissors.Helpers.Interfaces
{
    public interface IGameMoveViewModelHelper
    {
        List<GameMoveViewModel> GameMoveViewModels { get; }
    }
}
