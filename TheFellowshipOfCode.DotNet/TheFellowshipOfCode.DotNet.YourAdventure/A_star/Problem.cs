using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowshipOfCode.DotNet.YourAdventure.A_star
{
    class Problem
    {
        public Node Start { get; }
        public Node Goal { get; }

        public Problem(Node start, Node goal)
        {
            Start = start;
            Goal = goal;
        }

        public bool GoalReached(Path path)
        {
            return path.Nodes.Contains(Goal);
        }
    }
}
