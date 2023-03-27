
using System;
using Xunit;
using TestRobot = Codec.Robot.Application.Robot;

namespace Codec.Robot.Tests
{
    [Collection(nameof(RobotCollection))]
    public class RobotTests
    {
        private readonly RobotTestFixture _robotTestFixture;

        public RobotTests(RobotTestFixture robotTestFixture)
        {
            _robotTestFixture = robotTestFixture;
        }

        [Fact(DisplayName = "CreatePlateauBadArguments")]
        public void CreatePlateauBadArguments()
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentException>(() => _robotTestFixture.CreateInvalidPlateau());
        }

        [Fact(DisplayName = "CreatePlateauCorrectArguments")]
        public void CreatePlateauCorrectArguments()
        {
            //arrange
            var plateau = _robotTestFixture.Create5x5PLateau();
            //act
            //assert
            Assert.True(plateau.Z > 0);
        }

        [Fact(DisplayName = "RobotStartPosition")]
        public void RobotStartPosition()
        {
            //arrange
            var robot = _robotTestFixture.CreateRobot();
            //act
            //assert
            Assert.Equal("1,1,North", robot.GetCurrentPositionString());
        }

        [Fact(DisplayName = "RobotTurnLeft")]
        public void RobotTurnLeft()
        {
            //arrange
            var robot = _robotTestFixture.CreateRobot();
            //act
            robot.TurnLeft();
            //assert
            Assert.Equal(Application.CardinalPointEnum.West, robot.Direction);
        }

        [Fact(DisplayName = "RobotTurnRight")]
        public void RobotTurnRight()
        {
            //arrange
            var robot = _robotTestFixture.CreateRobot();
            //act
            robot.TurnRight();
            //assert
            Assert.Equal(Application.CardinalPointEnum.East, robot.Direction);
        }

        [Fact(DisplayName = "RobotMoveForward")]
        public void MoveForward()
        {
            //arrange
            var robot = _robotTestFixture.CreateRobot();
            //act
            robot.MoveForward();
            //assert
            Assert.Equal(2, robot.Position.Y);
        }

        [Fact(DisplayName = "RobotMoveForwardTwiceTurnLeftOnceMoveForwarOnce")]
        public void RobotMoveForwardTwiceTurnLeftOnceMoveForwarOnce()
        {
            //arrange
            var robot = _robotTestFixture.CreateRobot();
            //act
            robot.MoveForward();
            robot.MoveForward();
            robot.TurnRight();
            robot.MoveForward();
            robot.MoveForward();
            //assert
            Assert.Equal("3,3,East", robot.GetCurrentPositionString());
        }

        [Fact(DisplayName = "RobotMoveByCommand")]
        public void RobotMoveByCommand()
        {
            //arrange
            var robot = _robotTestFixture.CreateRobot();
            //act
            robot.ExecuteCommandString("FFRFLFLF");
            //assert
            Assert.Equal("1,4,West", robot.GetCurrentPositionString());
        }

        [Fact(DisplayName = "RobotMoveByCommandLimits")]
        public void RobotMoveByCommandLimits()
        {
            //arrange
            var robot = _robotTestFixture.CreateRobot();
            //act
            robot.ExecuteCommandString("FFFFFRFFRFFFRFFF");
            //assert
            Assert.Equal("1,2,West", robot.GetCurrentPositionString());
        }

        [Fact(DisplayName = "RobotMoveByCommandLimits2")]
        public void RobotMoveByCommandLimits2()
        {
            //arrange
            var robot = _robotTestFixture.CreateRobot();
            //act
            robot.ExecuteCommandString("RFFFFFFFFFFLFFFFFFLFL");
            //assert
            Assert.Equal("4,5,South", robot.GetCurrentPositionString());
        }

    }
}
