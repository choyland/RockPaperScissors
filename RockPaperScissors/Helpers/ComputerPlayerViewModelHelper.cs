using System.Collections.Generic;
using RockPaperScissors.Helpers.Interfaces;
using RockPaperScissors.ViewModels;

namespace RockPaperScissors.Helpers
{
    public class ComputerPlayerViewModelHelper : IComputerPlayerViewModelHelper
    {
        public List<ComputerPlayerTypeViewModel> ComputerPlayerTypeViewModels { get; }

        public ComputerPlayerViewModelHelper()
        {
            ComputerPlayerTypeViewModels = new List<ComputerPlayerTypeViewModel>
            {
                new ComputerPlayerTypeViewModel {FriendlyName = "Random", InputValue = "r"},
                new ComputerPlayerTypeViewModel {FriendlyName = "Tactical", InputValue = "t"},
            };
        }
    }
}
