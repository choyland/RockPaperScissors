using System.Collections.Generic;
using RockPaperScissors.ViewModels;

namespace RockPaperScissors.Helpers.Interfaces
{
    public interface IComputerPlayerViewModelHelper
    {
        List<ComputerPlayerTypeViewModel> ComputerPlayerTypeViewModels { get; }
    }
}
