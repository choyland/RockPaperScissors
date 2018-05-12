using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.ViewModels
{
    public class GameMoveViewModel
    {
        public GameMove GameMove { get; set; }
        public string FriendlyName { get; set; }
        public string InputValue { get; set; }
    }
}