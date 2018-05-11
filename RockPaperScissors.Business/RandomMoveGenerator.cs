using System;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business
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
