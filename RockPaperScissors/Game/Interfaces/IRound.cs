using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Game.Interfaces
{
    public interface IRound
    {
        void PlayRound(IPlayer normalPlayer, IComputerPlayer computerPlayer);
    }
}
