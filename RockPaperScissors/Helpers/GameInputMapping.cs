using System.Collections.Generic;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Helpers
{
    public static class GameInputMapping
    {
        public static List<GameMoveViewModel> GameMoves = new List<GameMoveViewModel>
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