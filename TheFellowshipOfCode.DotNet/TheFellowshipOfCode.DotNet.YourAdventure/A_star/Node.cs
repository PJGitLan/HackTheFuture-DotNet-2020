using HTF2020.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowshipOfCode.DotNet.YourAdventure.A_star
{
    class Node
    {
        public int[] Location { get; }
        public List<Move> Moves {get; set; }
        public float HeuristicValue { get; set; }
 
        public Node(float heuristicValue, int[] location)
        {
            Moves = new List<Move>();
            HeuristicValue = heuristicValue;
            Location = location;
        }
    }
}
