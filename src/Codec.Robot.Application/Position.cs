namespace Codec.Robot.Application
{
    public class Position
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void IncreseYPosition() => Y++;
        public void DecreaseYPosition() => Y--;
        public void IncreseXPosition() => X++;
        public void DecreaseXPosition() => X--;
    }
}
