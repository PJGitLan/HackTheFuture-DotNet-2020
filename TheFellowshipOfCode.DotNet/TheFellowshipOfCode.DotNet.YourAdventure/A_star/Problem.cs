using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowshipOfCode.DotNet.YourAdventure.A_star
{
    class Problem
    {
        public Node Start { get; set; }
        public Node Goal { get; set; }

        public bool GoalReached(Path path)
        {
            return path.Nodes.Contains(Goal);
        }
    }
}
