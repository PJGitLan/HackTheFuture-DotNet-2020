using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowshipOfCode.DotNet.YourAdventure.A_star
{
    class Path
    {
        public List<Node> Nodes { get; set; }
        public Node LeafNode { get; set; }
        public float Cost { get; set; }

        public Path(Node initialState)
        {
            Nodes = new List<Node>();
            Nodes.Add(initialState);

            LeafNode = initialState;

            Cost = 0;
        }

        public Path(Path currPath, Move nextMove)
        {
            Nodes = new List<Node>(currPath.Nodes);
            Nodes.Add(nextMove.NextNode);

            LeafNode = nextMove.NextNode;
            Cost = currPath.Cost + nextMove.Cost;
        }

        public void PathLog()
        {
            foreach (var node in Nodes)
            {
                Console.WriteLine($"Path: x: {node.Location[0]}, y: {node.Location[0]} ");
            }
            Console.WriteLine();
        }
    }
}
