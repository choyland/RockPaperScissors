using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business.Model.Interfaces
{
    public interface IComputerPlayer : IPlayer
    {
        GameMove GetComputerMove();
    }
}
