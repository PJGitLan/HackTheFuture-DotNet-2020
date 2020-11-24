using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowshipOfCode.DotNet.YourAdventure.A_star
{
    class Move
    {
        public Node NextNode { get;}
        public float Cost { get; }

        public Move(Node nextNode, float cost)
        {
            NextNode = nextNode;
            Cost = cost;
        }

    }
}
