using System;
using System.Linq;
using RockPaperScissors.Business.Calculators.Interfaces;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model;
using RockPaperScissors.Business.Model.Interfaces;
using RockPaperScissors.Configuration;
using RockPaperScissors.Configuration.Interfaces;
using RockPaperScissors.Game.Interfaces;
using RockPaperScissors.Helpers;
using RockPaperScissors.Helpers.Interfaces;
using RockPaperScissors.ViewModels;
using RockPaperScissors.Wrappers;
using RockPaperScissors.Wrappers.Interfaces;

namespace RockPaperScissors.Game
{
    public class GameRunner : IGameRunner
    {
        private readonly IOverallScoreCalculator _overallScoreCalculator;
        private readonly IRound _round;
        private readonly IConfiguration _configuration;
        private readonly IInputOutputWrapper _inputOutputWrapper;
        private readonly IComputerPlayerViewModelHelper _computerPlayerViewModelHelper;
        private readonly IGameMoveViewModelHelper _gameMoveViewModelHelper;
        private readonly Func<string, IComputerPlayer> _computerPlayerFactory;
        
        private readonly IPlayer _normalPlayer;
        private IComputerPlayer _computerPlayer;

        private int _roundsPlayed;
        
        public GameRunner(IOverallScoreCalculator overallScoreCalculator, Func<string, IComputerPlayer> computerPlayerFactory, IRound round, IConfiguration configuration, IInputOutputWrapper inputOutputWrapper, IComputerPlayerViewModelHelper computerPlayerViewModelHelper, IGameMoveViewModelHelper gameMoveViewModelHelper)
        {
            _overallScoreCalculator = overallScoreCalculator;
            _computerPlayerFactory = computerPlayerFactory;
            _round = round;
            _configuration = configuration;
            _inputOutputWrapper = inputOutputWrapper;
            _computerPlayerViewModelHelper = computerPlayerViewModelHelper;
            _gameMoveViewModelHelper = gameMoveViewModelHelper;
            _normalPlayer = new NormalPlayer();
        }

        public void StartGame()
        {
            var bestOf = _configuration.BestOf;

            IntroduceGame();
            ChooseComputerPlayerType();
            DisplayRules();

            while (!_overallScoreCalculator.HasAPlayerWon(bestOf, _normalPlayer, _computerPlayer) && _roundsPlayed < bestOf)
            {
                _round.PlayRound(_normalPlayer, _computerPlayer);
                _roundsPlayed++;
            }

            DisplayFinalResults();

        }

        private void DisplayFinalResults()
        {
            _inputOutputWrapper.WriteLine($"Game over! You scored : {_normalPlayer.Wins} | Computer scored : {_computerPlayer.Wins}");
            var overallResult = _overallScoreCalculator.CalculateOverallWinner(_normalPlayer, _computerPlayer);

            if (overallResult == Result.Draw)
            {
                _inputOutputWrapper.WriteLine("It's a draw!");
            }
            else if (overallResult == Result.Player1Wins)
            {
                _inputOutputWrapper.WriteLine("You won!");
            }
            else
            {
                _inputOutputWrapper.WriteLine("Computer won!");
            }

            _inputOutputWrapper.ReadLine();
        }

        private void DisplayRules()
        {
            _inputOutputWrapper.WriteLine($"The game will be best of {_configuration.BestOf}");
            _inputOutputWrapper.WriteLine("You will be prompted to enter your choice of rock paper scissors and you can submit your choice using one of the following:");

            foreach (var gameMoveViewModel in _gameMoveViewModelHelper.GameMoveViewModels)
            {
                _inputOutputWrapper.WriteLine($"{gameMoveViewModel.InputValue} for {gameMoveViewModel.FriendlyName}");
            }

            _inputOutputWrapper.WriteLine("Press enter to begin!");
            _inputOutputWrapper.ReadLine();
        }

        private void IntroduceGame()
        {
            _inputOutputWrapper.WriteLine("Welcome to Rock, Paper, Scissors! Today you'll be playing against the computer - press enter to begin!");
            _inputOutputWrapper.ReadLine();
        }

        private void ChooseComputerPlayerType()
        {
            var computerPlayerTypeViewModels = _computerPlayerViewModelHelper.ComputerPlayerTypeViewModels;
            _inputOutputWrapper.WriteLine($"You can choose from {computerPlayerTypeViewModels.Count} types of computer player. Please enter:");

            foreach (var computerPlayerTypeViewModel in computerPlayerTypeViewModels)
            {
                _inputOutputWrapper.WriteLine($"{computerPlayerTypeViewModel.InputValue} for {computerPlayerTypeViewModel.FriendlyName}");
            }

            ComputerPlayerTypeViewModel computerTypeChoice = null;

            while (computerTypeChoice == null)
            {
                var choice = _inputOutputWrapper.ReadLine();
                computerTypeChoice = computerPlayerTypeViewModels.FirstOrDefault(x => x.InputValue == choice);
                if (computerTypeChoice == null)
                {
                    _inputOutputWrapper.WriteLine("That was an invalid choice, please try again");
                }
            }
            _computerPlayer = _computerPlayerFactory(computerTypeChoice.InputValue);
        }
    }
}
