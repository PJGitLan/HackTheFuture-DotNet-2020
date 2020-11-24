using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowshipOfCode.DotNet.YourAdventure.A_star
{
    class Node
    {
        public List<Move> Moves { get; set; }
        public float HeuristicValue { get; }

        public Node(float heuristicValue)
        {
            Moves = new List<Move>();
            HeuristicValue = heuristicValue;
        }
    }
}
