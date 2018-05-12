using System;
using RockPaperScissors.Business.Enum;
using RockPaperScissors.Business.MoveGenerators.Interfaces;

namespace RockPaperScissors.Business.MoveGenerators
{
    public class RandomMoveGenerator : IRandomMoveGenerator
    {

        // Random initialized using system clock so safer to use same instance
        private static readonly Random Random;

        static RandomMoveGenerator()
        {
            Random = new Random();
        }

        public GameMove GenerateRandomMove()
        {
            var gameMoveLength = System.Enum.GetNames(typeof(GameMove)).Length;

            var randomValidNumber = Random.Next(0, gameMoveLength - 1);

            return (GameMove) randomValidNumber;
        }
    }
}
