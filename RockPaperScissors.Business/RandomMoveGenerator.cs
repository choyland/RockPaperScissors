using System;
using RockPaperScissors.Business.Enum;

namespace RockPaperScissors.Business
{
    public static class RandomMoveGenerator
    {

        // Random initialized using system clock so safer to use same instance
        private static readonly Random _random;

        static RandomMoveGenerator()
        {
            _random = new Random();
        }

        public static GameMove GetRandomMove()
        {
            var gameMoveLength = System.Enum.GetNames(typeof(GameMove)).Length;

            var randomValidNumber = _random.Next(0, gameMoveLength - 1);

            return (GameMove) randomValidNumber;
        }
    }
}
