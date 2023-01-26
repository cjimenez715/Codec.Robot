using System;

namespace Codec.Robot.Application
{
    public class Robot
    {
        private const int INITIAL_X = 1;
        private const int INITIAL_Y = 1;

        public Position Position { get;  private set; }
        public Plateau Plateau { get; private set; }
        public CardinalPointEnum Direction { get; private set; }
        private string Commands;


        public Robot(Plateau plateau)
        {
            Position = new Position(INITIAL_X, INITIAL_Y);
            Direction = CardinalPointEnum.North;
            Commands = string.Empty;
            Plateau = plateau;
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case CardinalPointEnum.North:
                    Direction = CardinalPointEnum.West;
                    break;
                case CardinalPointEnum.West:
                    Direction = CardinalPointEnum.South;
                    break;
                case CardinalPointEnum.South:
                    Direction = CardinalPointEnum.East;
                    break;
                case CardinalPointEnum.East:
                    Direction = CardinalPointEnum.North;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case CardinalPointEnum.North:
                    Direction = CardinalPointEnum.East;
                    break;
                case CardinalPointEnum.East:
                    Direction = CardinalPointEnum.South;
                    break;
                case CardinalPointEnum.South:
                    Direction = CardinalPointEnum.West;
                    break;
                case CardinalPointEnum.West:
                    Direction = CardinalPointEnum.North;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void MoveForward()
        {
            if(!ValidateMovement()) return;
            switch (Direction)
            {
                case CardinalPointEnum.North:
                    Position.IncreseYPosition();
                    break;
                case CardinalPointEnum.East:
                    Position.IncreseXPosition();
                    break;
                case CardinalPointEnum.South:
                    Position.DecreaseYPosition();
                    break;
                case CardinalPointEnum.West:
                    Position.DecreaseXPosition();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void ExecuteCommandString(string commands)
        {
            Commands = commands.ToUpper();
            foreach (var nextCommand in ReadCommand()) ExecuteSingleCommand(nextCommand.ToString());
        }

        private void ExecuteSingleCommand(string command)
        {
            switch (command)
            {
                case "L":
                    TurnLeft();
                    break;
                case "R":
                    TurnRight();
                    break;
                case "F":
                    MoveForward();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private bool ValidateMovement()
        {
            switch (Direction)
            {
                case CardinalPointEnum.North:
                    return Position.Y < Plateau.Y;
                case CardinalPointEnum.East:
                    return Position.X < Plateau.X;
                case CardinalPointEnum.South:
                    return Position.Y > INITIAL_Y;
                case CardinalPointEnum.West:
                    return Position.X > INITIAL_X;
                default:
                    return true;
            }
        }
        private char[] ReadCommand() => Commands.ToCharArray();

        public string GetCurrentPositionString() => $"{Position.X},{Position.Y},{Direction}";

    }
}
