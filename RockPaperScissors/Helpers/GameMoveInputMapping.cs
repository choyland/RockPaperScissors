using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Helpers
{
    public static class GameMoveInputMapping
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

public class GameMoveViewModel
{
    public GameMove GameMove { get; set; }
    public string FriendlyName { get; set; }
    public string InputValue { get; set; }
}

