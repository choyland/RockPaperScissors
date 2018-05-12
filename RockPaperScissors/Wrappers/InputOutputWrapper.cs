using System;
using RockPaperScissors.Wrappers.Interfaces;

namespace RockPaperScissors.Wrappers
{
    public class InputOutputWrapper : IInputOutputWrapper
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
