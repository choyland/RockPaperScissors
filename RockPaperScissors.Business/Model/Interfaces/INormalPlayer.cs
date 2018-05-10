using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.Model.Interfaces
{
    public interface INormalPlayer : IPlayer
    {
        GameMove Move { get; set; }
    }
}
