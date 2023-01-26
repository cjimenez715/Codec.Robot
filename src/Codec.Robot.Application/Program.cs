using System;

// Robot: Position location (x, y , Z), Z is Orientation (W, E, N ,S)
// Plateau: MAtrix of positions formed by => (x, y, Z), (0, 0, N) => (x=0, y=0, Z=N)
//          MinX = 0, minY = 0 => (x, y) => (5, 5)
// There is no (0, 0) position
// Commands: Str => L = Spin Left, R Spin  right, F Move in the current position => (FFRFLFLF)
// Start Robot position (1, 1, N)
// 1. Input Line: Plateau's Size: (5z5)
// 2. Input Line: Robot Command (FFRFLFLF)
// Output (x, y , Final Direction) => 1,4,West

// Robot movements
// 1.-Robot should spin Left
// 2.-Robot should spin Right
// 3.-Robot should Move Forward

namespace Codec.Robot.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert Plateau's Surface Ex.(5x5):");
            string surface = Console.ReadLine();
            Console.WriteLine("Insert Robot Command Ex.(FFRFLFLF):");
            string robotCommand = Console.ReadLine();

            var plateauX = int.Parse(surface.Split("x")[0]);
            var plateauY = int.Parse(surface.Split("x")[1]);
            var plateau = new Plateau(plateauX, plateauY);
            var robot = new Robot(plateau);
            robot.ExecuteCommandString(robotCommand);
            Console.WriteLine(robot.GetCurrentPositionString());
        }
    }
}
