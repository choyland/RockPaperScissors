using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissors.Business;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Implementation;
using RockPaperScissors.Business.Model.Interfaces;
using RockPaperScissors.Helpers;

namespace RockPaperScissors
{
    public interface IGame
    {
        void StartGame();
    }
    public class Game : IGame
    {
        private readonly IOverallScoreCalculator _overallScoreCalculator;
        private readonly IResultCalculator _resultCalculator;

        // TODO Get from configuration
        private const int BestOf = 3;
        private readonly INormalPlayer _normalPlayer;
        private IComputerPlayer _computerPlayer;

        public Game(IOverallScoreCalculator overallScoreCalculator, IResultCalculator resultCalculator)
        {
            _overallScoreCalculator = overallScoreCalculator;
            _resultCalculator = resultCalculator;
            _normalPlayer = new NormalPlayer();
        }

        public void StartGame()
        {
            IntroduceGame();
            ChooseComputerPlayerType();
            DisplayRules();

            while (!_overallScoreCalculator.HasAPlayerWon(BestOf, _normalPlayer, _computerPlayer))
            {
                PlayRound();
            }

            DisplayFinalResults();

        }

        private void DisplayFinalResults()
        {
            
        }

        private void PlayRound()
        {
            GameMoveViewModel chosenMove = null;

            while (chosenMove == null)
            {
                Console.WriteLine("Please enter your choice:");
                var choice = Console.ReadLine();
                chosenMove = GameMoveInputMapping.GameMoves.FirstOrDefault(x => x.InputValue == choice);
                if (chosenMove == null)
                {
                    Console.WriteLine("That was an invalid choice, please try again");
                }
            }

            var computerGameMove =
                GameMoveInputMapping.GameMoves.FirstOrDefault(x => x.GameMove == _computerPlayer.GetComputerMove());

            if (computerGameMove == null)
            {
                throw new ApplicationException("Error Generating computer choice");
            }

            var result = _resultCalculator.CalculateRoundResult(chosenMove.GameMove, computerGameMove.GameMove);

            Console.WriteLine($"Computer chose: {computerGameMove.FriendlyName}");

            var resultString = string.Empty;
            if (result == RoundResult.Draw)
            {
                resultString = "Draw!";
                
            }
            else if (result == RoundResult.Player1Wins)
            {
                resultString = "You win!";
                IncrementWins(_normalPlayer);
            }
            else
            {
                resultString = "Computer wins!";
                IncrementWins(_computerPlayer);
            }

            Console.WriteLine(resultString);
        }

        private void IncrementWins(IPlayer player)
        {
            player.Wins++;
        }

        private void DisplayRules()
        {
            Console.WriteLine($"The game will be best of {BestOf}");
            Console.WriteLine("You will be prompted to enter your choice of rock paper scissors and you can submit your choice using one of the following:");
            foreach (var gameMoveViewModel in GameMoveInputMapping.GameMoves)
            {
                Console.WriteLine($"{gameMoveViewModel.InputValue} for {gameMoveViewModel.FriendlyName}");
            }

            Console.WriteLine("Press enter to begin!");
            Console.ReadLine();
        }

        private static void IntroduceGame()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors! Today you'll be playing against the computer - press enter to begin!");
            Console.ReadLine();
        }

        private void ChooseComputerPlayerType()
        {
            Console.WriteLine("You can play against a random or a tactical computer. Enter \"r\" for random or \"t\" for tactical");
            var computerPlayerChoice = Console.ReadLine();

            //validate input

            if (computerPlayerChoice == "r")
            {
                _computerPlayer = new RandomComputerPlayer();
            }

            if (computerPlayerChoice == "t")
            {
                _computerPlayer = new TacticalComputerPlayer();
            }
        }
    }
}
