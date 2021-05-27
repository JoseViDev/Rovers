using System;
using System.Collections.Generic;
using System.Text;

namespace NasaMars
{

    public enum Directions
    {
        North,
        West,
        East,
        South,
    }

    public enum State
    {
        Successful,
        Unsuccessful,
    }

    public enum Instruction
    {
        Left,
        Right,
        Move,
    }

    public interface IMovable
    {
        int X { get; set; }
        int Y { get; set; }
        Directions Direction { get; set; }
        State Status { get; }
        string ErrorMessage { get; }

        void ExecuteInstruction(Instruction instruction);
    }
}
