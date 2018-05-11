using System;
using System.Linq;
using RockPaperScissors.Business;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Implementation;
using RockPaperScissors.Business.Model.Interfaces;
using RockPaperScissors.Helpers;

namespace RockPaperScissors
{
    public class Game : IGame
    {
        private readonly IOverallScoreCalculator _overallScoreCalculator;
        private readonly IResultCalculator _resultCalculator;
        private readonly Func<string, IComputerPlayer> _computerPlayerFactory;

        private readonly INormalPlayer _normalPlayer;
        private IComputerPlayer _computerPlayer;

        // TODO Get from configuration
        private const int BestOf = 3;

        private int _roundsPlayed;


        public Game(IOverallScoreCalculator overallScoreCalculator, IResultCalculator resultCalculator, Func<string, IComputerPlayer> computerPlayerFactory)
        {
            _overallScoreCalculator = overallScoreCalculator;
            _resultCalculator = resultCalculator;
            _computerPlayerFactory = computerPlayerFactory;
            _normalPlayer = new NormalPlayer();
        }

        public void StartGame()
        {
            IntroduceGame();
            ChooseComputerPlayerType();
            DisplayRules();

            while (!_overallScoreCalculator.HasAPlayerWon(BestOf, _normalPlayer, _computerPlayer) && _roundsPlayed < BestOf)
            {
                PlayRound();
                _roundsPlayed++;
            }

            DisplayFinalResults();

        }

        private void DisplayFinalResults()
        {
            Console.WriteLine($"Game over! You scored : {_normalPlayer.Wins} | Computer scored : {_computerPlayer.Wins}");
            var overallResult = _overallScoreCalculator.CalculateOverallWinner(_normalPlayer, _computerPlayer);

            if (overallResult == Result.Draw)
            {
                Console.WriteLine("It's a draw!");
            }
            else if (overallResult == Result.Player1Wins)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("Computer won!");
            }
            Console.ReadLine();
        }

        private void PlayRound()
        {
            GameMoveViewModel chosenMove = null;

            while (chosenMove == null)
            {
                Console.WriteLine("Please enter your choice:");
                var choice = Console.ReadLine();
                chosenMove = GameInputMapping.GameMoves.FirstOrDefault(x => x.InputValue == choice);
                if (chosenMove == null)
                {
                    Console.WriteLine("That was an invalid choice, please try again");
                }
            }

            var computerGameMove = _computerPlayer.GetComputerMove();
            var computerGameMoveViewModel = GameInputMapping.GameMoves.FirstOrDefault(x => x.GameMove == computerGameMove);

            if (computerGameMoveViewModel == null)
            {
                throw new ApplicationException("Error Generating computer choice");
            }

            var result = _resultCalculator.CalculateRoundResult(chosenMove.GameMove, computerGameMove);

            Console.WriteLine($"Computer chose: {computerGameMoveViewModel.FriendlyName}");

            var resultString = string.Empty;
            if (result == Result.Draw)
            {
                resultString = "Draw!";
                
            }
            else if (result == Result.Player1Wins)
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
            foreach (var gameMoveViewModel in GameInputMapping.GameMoves)
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

            // TODO validate input

            _computerPlayer = _computerPlayerFactory(computerPlayerChoice);
        }
    }
}
