using System;

namespace NasaMars
{
    public class Rover: IMovable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
        public State Status { get; internal set; }
        public string ErrorMessage { get; internal set; }

        public Rover() 
        {
            Status = State.Successful;
            ErrorMessage = "";
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Directions.North: Direction = Directions.West; break;
                case Directions.East: Direction = Directions.North; break;
                case Directions.South: Direction = Directions.East; break;
                case Directions.West: Direction = Directions.South; break;
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Directions.North: Direction = Directions.East; break;
                case Directions.East: Direction = Directions.South; break;
                case Directions.South: Direction = Directions.West; break;
                case Directions.West: Direction = Directions.North; break;
            }
        }

        public void Move()
        {
            // moves the rover in the selected direction, also bounds are validated preventing from going outside the grid
            switch (Direction)
            {
                case Directions.North:
                    if (Y + 1 > Grid.Instance.LimitY)
                    {
                        GenerateError(X, Y + 1);
                    }
                    else
                    {
                        Y += 1;
                    }
                    break;
                case Directions.East:
                    if (X + 1 > Grid.Instance.LimitX)
                    {
                        GenerateError(X + 1, Y);
                    }
                    else
                    {
                        X += 1;
                    }
                    break;
                case Directions.South:
                    if (Y - 1 == -1)
                    {
                        GenerateError(X, Y - 1);
                    }
                    else
                    {
                        Y -= 1;
                    }
                    break;
                case Directions.West:
                    if (X - 1 == -1)
                    {
                        GenerateError(X - 1, Y);
                    }
                    else
                    {
                        X -= 1;
                    }
                    break;
            }
        }

        private void GenerateError(int x, int y)
        {
            Status = State.Unsuccessful;
            ErrorMessage = "Out of boundaries: can not move to X=" + x + " and Y=" + y;
        }

        public override string ToString()
        {
            return X + " " + Y + " " + Direction + (Status == State.Successful ? "" : " - " + ErrorMessage);
        }

        public void ExecuteInstruction(Instruction instruction)
        {
            switch (instruction)
            {
                case Instruction.Left: TurnLeft(); break;
                case Instruction.Right: TurnRight(); break;
                case Instruction.Move: Move(); break;
            }
        }
    }
}
