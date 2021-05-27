using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NasaMars
{
    public class Tour
    {

        public Tour()
        {
            Instructions = new List<Instruction>();
        }

        // strategy pattern used to allow more than just rovers
        public IMovable Vehicle { get; set; }
        public List<Instruction> Instructions { get; set; }

        public override string ToString()
        {
            string[] result = Instructions.Select(x => x == Instruction.Left ? "L" : (x == Instruction.Right ? "R" : "M")).ToArray();

            return Vehicle.ToString() + " - " + string.Join("",result);
        }

    }
}
