using System;
using System.Linq;
using RockPaperScissors.Business;
using RockPaperScissors.Business.Calculators;
using RockPaperScissors.Business.Calculators.Interfaces;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;
using RockPaperScissors.Game.Interfaces;
using RockPaperScissors.Helpers;
using RockPaperScissors.Helpers.Interfaces;
using RockPaperScissors.ViewModels;
using RockPaperScissors.Wrappers;
using RockPaperScissors.Wrappers.Interfaces;

namespace RockPaperScissors.Game
{
    public class Round : IRound
    {
        private readonly IRoundCalculator _roundCalculator;
        private readonly IInputOutputWrapper _inputOutputWrapper;
        private readonly IGameMoveViewModelHelper _gameMoveViewModelHelper;

        public Round(IRoundCalculator roundCalculator, IInputOutputWrapper inputOutputWrapper, IGameMoveViewModelHelper gameMoveViewModelHelper)
        {
            _roundCalculator = roundCalculator;
            _inputOutputWrapper = inputOutputWrapper;
            _gameMoveViewModelHelper = gameMoveViewModelHelper;
        }

        public void GetUserChoice()
        {
            
        }

        public void PlayRound(IPlayer normalPlayer, IComputerPlayer computerPlayer)
        {
            GameMoveViewModel chosenMove = null;

            while (chosenMove == null)
            {
                _inputOutputWrapper.WriteLine("Please enter your choice:");
                var choice = _inputOutputWrapper.ReadLine();
                chosenMove = _gameMoveViewModelHelper.GameMoveViewModels.FirstOrDefault(x => x.InputValue == choice);
                if (chosenMove == null)
                {
                    _inputOutputWrapper.WriteLine("That was an invalid choice, please try again");
                }
            }

            var computerGameMove = computerPlayer.GetComputerMove();
            var computerGameMoveViewModel = _gameMoveViewModelHelper.GameMoveViewModels.FirstOrDefault(x => x.GameMove == computerGameMove);

            if (computerGameMoveViewModel == null)
            {
                throw new ApplicationException("Error Generating computer choice");
            }

            var result = _roundCalculator.CalculateRoundResult(chosenMove.GameMove, computerGameMove);

            _inputOutputWrapper.WriteLine($"Computer chose: {computerGameMoveViewModel.FriendlyName}");

            string resultString = null;
            switch (result)
            {
                case Result.Draw:
                    resultString = "Draw!";
                    break;
                case Result.Player1Wins:
                    resultString = "You win!";
                    IncrementWins(normalPlayer);
                    break;
                case Result.Player2Wins:
                    resultString = "Computer wins!";
                    IncrementWins(computerPlayer);
                    break;
            }

            _inputOutputWrapper.WriteLine(resultString);
        }

        private static void IncrementWins(IPlayer player)
        {
            player.Wins++;
        }
    }
}
