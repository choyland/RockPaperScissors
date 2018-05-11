using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;

namespace RockPaperScissors.Business.Model.Implementation
{
    public class TacticalComputerPlayer : IComputerPlayer
    {
        private readonly ITacticalMoveGenerator _tacticalMoveGenerator;
        private readonly IRandomMoveGenerator _randomMoveGenerator;

        private static GameMove? _previousMove = null;

        public TacticalComputerPlayer(ITacticalMoveGenerator tacticalMoveGenerator, IRandomMoveGenerator randomMoveGenerator)
        {
            _tacticalMoveGenerator = tacticalMoveGenerator;
            _randomMoveGenerator = randomMoveGenerator;
        }

        public int Wins { get; set; }
        public GameMove GetComputerMove()
        {
            // if previous move is null we know it is the first move so generate a random move to start
            var move = !_previousMove.HasValue ? _randomMoveGenerator.GenerateRandomMove() : _tacticalMoveGenerator.GenerateTacticalMove(_previousMove.Value);
            _previousMove = move;

            return move;
        }
    }
}
