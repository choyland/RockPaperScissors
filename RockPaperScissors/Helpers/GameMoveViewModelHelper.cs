using System.Collections.Generic;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Helpers.Interfaces;
using RockPaperScissors.ViewModels;

namespace RockPaperScissors.Helpers
{
    public class GameMoveViewModelHelper : IGameMoveViewModelHelper
    {
        public List<GameMoveViewModel> GameMoveViewModels { get; }

        public GameMoveViewModelHelper()
        {
            GameMoveViewModels = new List<GameMoveViewModel>
            {
                new GameMoveViewModel
                {
                    GameMove = GameMove.Paper,
                    FriendlyName = "Paper",
                    InputValue = "p"
                },
                new GameMoveViewModel
                {
                    GameMove = GameMove.Rock,
                    FriendlyName = "Rock",
                    InputValue = "r"
                },
                new GameMoveViewModel
                {
                    GameMove = GameMove.Scissors,
                    FriendlyName = "Scissors",
                    InputValue = "s"
                }
            };
        }
    }
}