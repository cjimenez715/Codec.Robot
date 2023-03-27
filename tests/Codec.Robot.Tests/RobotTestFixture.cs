using Codec.Robot.Application;
using System;
using Xunit;
using TestRobot = Codec.Robot.Application.Robot;

namespace Codec.Robot.Tests
{
    //Fixtures
    [CollectionDefinition(nameof(RobotCollection))]
    public class RobotCollection : ICollectionFixture<RobotTestFixture> { }

    public class RobotTestFixture : IDisposable
    {
        public Plateau CreateInvalidPlateau()
        {
            return new Plateau(0, 0);
        }

        public Plateau Create5x5PLateau()
        {
            return new Plateau(5, 5);
        }

        public TestRobot CreateRobot()
        {
            var plateau = new Plateau(5, 5);
            var robot = new TestRobot(plateau);
            return robot;
        }

        public void Dispose()
        {

        }
    }
}
