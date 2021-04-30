using System;
using System.Collections.Generic;
using System.Text;

namespace XLN.Models
{
    public class RobotInstructions
    {
        public string UpperRightCoordination { get; set; }
        public List<Robot> Robots { get; set; }

        public class Robot
        {
            public int RobotId { get; set; }
            public string CurrentPosition { get; set; }
            public string Instruction { get; set; }
        }
    }
}
