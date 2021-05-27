using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NasaMars
{
    public class InputParser
    {
        static public void ParseGrid(string inputText)
        {
            // first line is always the grid limits and is required
            string[] size = inputText.Split(Environment.NewLine).First().Split(" ".ToCharArray());
            Grid.Instance.LimitX = int.Parse(size[0]);
            Grid.Instance.LimitY = int.Parse(size[1]);
        }

        static public List<Tour> ParseTours(string inputText)
        {
            List<Tour> tours = new List<Tour>();
            string[] lines = inputText.Split(Environment.NewLine);

            // besides the first line, each 2 lines are used to represent the rover and their instructions
            for (int i = 1; i < lines.Count(); i++)
            {
                Tour tour = new Tour();
                tour.Vehicle = ParseRover(lines[i]);
                i += 1;
                tour.Instructions = ParseInstructions(lines[i]);

                tours.Add(tour);
            }

            return tours;
        }

        static public List<Instruction> ParseInstructions(string line)
        {
            List<Instruction> instructions = new List<Instruction>();

            foreach (char order in line)
            {
                switch (order)
                {
                    case 'L': instructions.Add(Instruction.Left); break;
                    case 'R': instructions.Add(Instruction.Right); break;
                    case 'M': instructions.Add(Instruction.Move); break;
                }
            }

            return instructions;
        }

        static private Rover ParseRover(string line)
        {
            // each rover line represents: the X position, a blank space working as separator, the position Y, a blank space working as separator, and the direction

            Rover rover = new Rover();
            string[] position = line.Split(" ".ToCharArray());
            int x = int.Parse(position[0]);
            int y = int.Parse(position[1]);
            string c = position[2];

            rover.X = x;
            rover.Y = y;
            switch (c)
            {
                case "N": rover.Direction = Directions.North; break;
                case "E": rover.Direction = Directions.East; break;
                case "S": rover.Direction = Directions.South; break;
                case "W": rover.Direction = Directions.West; break;
            }

            return rover;
        }
    }
}
