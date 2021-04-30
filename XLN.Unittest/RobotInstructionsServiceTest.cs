using NUnit.Framework;
using System;
using System.Collections.Generic;
using XLN.Models;
using static XLN.Models.RobotInstructions;

namespace XLN.Unittest
{
    public class RobotInstructionsTest
    {
        private RobotInstructions instructions;
        private RobotInstructionsService service;

        [SetUp]
        public void Setup()
        {
            Robot robot1 = new Robot()
            {
                RobotId = 1,
                CurrentPosition = "1 2 N",
                Instruction = "<^<^<^<^^"
            };
            Robot robot2 = new Robot()
            {
                RobotId = 2,
                CurrentPosition = "3 3 E",
                Instruction = "^^>^^>^>>^"
            };
            var robots = new List<Robot>();
            robots.Add(robot1);
            robots.Add(robot2);
            instructions = new Models.RobotInstructions()
            {
                UpperRightCoordination = " 5 5 ",
                Robots = robots
            };
            service = new RobotInstructionsService(instructions);
        }

        [Test]
        public void GivingRobotInstructions()
        {
            var result = service.GiveRobotInstructions();
            Assert.That(result, Is.EqualTo("1 3 N" + Environment.NewLine + "5 1 E" + Environment.NewLine));
        }
    }
}