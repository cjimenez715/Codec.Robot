using System;

namespace Codec.Robot.Application
{
    public class Plateau
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Z { get; protected set; }

        public Plateau(int x, int y)
        {
            X = x;
            Y = y;
            Z = x * y;
            if (Z <= 0)
                throw new ArgumentException();
        }
    }
}
