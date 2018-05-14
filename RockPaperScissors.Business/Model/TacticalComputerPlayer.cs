using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.Model.Interfaces;
using RockPaperScissors.Business.MoveGenerators.Interfaces;

namespace RockPaperScissors.Business.Model
{
    public class TacticalComputerPlayer : IComputerPlayer
    {
        private readonly ITacticalMoveGenerator _tacticalMoveGenerator;
        private readonly IRandomMoveGenerator _randomMoveGenerator;

        public GameMove? PreviousMove { get; set; } = null;

        public TacticalComputerPlayer(ITacticalMoveGenerator tacticalMoveGenerator, IRandomMoveGenerator randomMoveGenerator)
        {
            _tacticalMoveGenerator = tacticalMoveGenerator;
            _randomMoveGenerator = randomMoveGenerator;
        }

        public int Wins { get; set; }
        public GameMove GetComputerMove()
        {
            // if previous move is null we know it is the first move so generate a random move to start
            var move = !PreviousMove.HasValue ? _randomMoveGenerator.GenerateRandomMove() : _tacticalMoveGenerator.GenerateTacticalMove(PreviousMove.Value);
            PreviousMove = move;

            return move;
        }
    }
}
