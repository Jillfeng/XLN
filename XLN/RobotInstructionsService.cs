using System;
using XLN.Models;

namespace XLN
{
    public class RobotInstructionsService
    {
        private RobotInstructions instructions;
        private Position position;
        public RobotInstructionsService(RobotInstructions instructions)
        {
            this.instructions = instructions;
        }
        public string GiveRobotInstructions()
        {
            string robotOutput = "";
            string forward = "^";
            string left = "<";
            string right = ">";

            foreach (var robot in instructions.Robots)
            {
                position = new Position();
                var currentPosition = robot.CurrentPosition.Split(" ");
                var instructions = robot.Instruction;

                position.X = int.Parse(currentPosition[0]);
                position.Y = int.Parse(currentPosition[1]);
                position.D = WorkOutDirection(currentPosition[2]);
              
                for(var c = 0; c < instructions.Length; c++)
                {
                    var instruction = instructions[c].ToString();
                    if(instruction == forward && position.D == Direction.N)
                    {
                        position.Y++;
                    }
                    if(instruction == forward && position.D == Direction.W)
                    {
                        position.X--;
                    }
                    if(instruction == forward && position.D == Direction.S)
                    {
                        position.Y--;
                    }
                    if(instruction == forward && position.D == Direction.E)
                    {
                        position.X++;
                    }
                    if(instruction == left )
                    {                       
                        if(position.D == Direction.E)
                        {
                            position.D = Direction.N;
                        }
                        else
                        {
                            position.D++;
                        }
                    }
                    if(instruction == right)
                    {
                        if (position.D == Direction.N)
                        {
                            position.D = Direction.E;
                        }
                        else 
                        {
                            position.D--;
                        }
                    }
                }

                var robotPosition = GetDirectionEnumName(position.D);

                robotOutput += position.X.ToString() + " " + position.Y.ToString() + " " + robotPosition + Environment.NewLine;
            }
            return robotOutput;
        }
        private Direction WorkOutDirection(string currentPosition)
        {
            Direction direction = new Direction();
            switch (currentPosition)
            {
                case "N":
                    direction = Direction.N;
                    break;
                case "W":
                    direction = Direction.W;
                    break;
                case "S":
                    direction = Direction.S;
                    break;
                case "E":
                    direction = Direction.E;
                    break;
            }
            return direction;
        }
        private string GetDirectionEnumName(Direction direction)
        {
            return Enum.GetName(typeof(Direction), direction);
        }
    }
}
