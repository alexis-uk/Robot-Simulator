using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot;

namespace Test
{
    [TestClass]
    public class RobotTest
    {
        [DataTestMethod]
        [DataRow(-1,0)]
        [DataRow(0,-1)]
        [DataRow(-1, -1)]
        [DataRow(5, 6)]
        [DataRow(6, 5)]
        [DataRow(6, 6)]
        public void RobotCannotBePlacedOutsideGrid(int x, int y)
        {
            var robot = new Robot.Robot(new Tabletop(5,5));
            var result=robot.Place(new Point(x, y));
            Assert.IsFalse(result);
        }


        [DataTestMethod]
        [DataRow(5, 5, Direction.NORTH)]
        [DataRow(5, 5, Direction.EAST)]
        [DataRow(0, 0, Direction.WEST)]
        [DataRow(0, 0, Direction.SOUTH)]
        [DataRow(0, 5, Direction.NORTH)]
        [DataRow(0, 5, Direction.WEST)]
        [DataRow(5, 0, Direction.EAST)]
        [DataRow(5, 0, Direction.SOUTH)]
        public void RobotCannotAdvanceOutsideGrid(int x, int y, Direction direction)
        {
            var robot = new Robot.Robot(new Tabletop(5, 5));
            robot.Place(new Point(x, y));
            robot.Direction = direction;
            var result = robot.Move();
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(0, 0, Direction.NORTH, "0,1,NORTH")]
        [DataRow(5, 5, Direction.SOUTH, "5,4,SOUTH")]
        [DataRow(0, 5, Direction.EAST, "1,5,EAST")]
        public void VerifyRobotNewStateWhenValidMove(int x, int y, Direction direction,string expected)
        {
            var robot = new Robot.Robot(new Tabletop(5, 5));
            robot.Place(new Point(x, y));
            robot.Direction = direction;
            var result = robot.Move();
            Assert.IsTrue(result);
            Assert.AreEqual(robot.Report, expected);
        }

        [DataTestMethod]
        [DataRow(0, 0, Direction.NORTH, "0,1,NORTH")]
        [DataRow(5, 5, Direction.SOUTH, "5,4,SOUTH")]
        [DataRow(0, 5, Direction.EAST, "1,5,EAST")]
        public void VerifyRobotNewStateWhenInvalidMove(int x, int y, Direction direction, string expected)
        {
            var robot = new Robot.Robot(new Tabletop(5, 5));
            robot.Place(new Point(x, y));
            robot.Direction = direction;
            var result = robot.Move();
            Assert.IsTrue(result);
            Assert.AreEqual(robot.Report, expected);
        }

    }
}
