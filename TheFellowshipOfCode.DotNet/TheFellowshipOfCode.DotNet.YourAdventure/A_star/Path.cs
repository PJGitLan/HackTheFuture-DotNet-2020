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

        public Path(Path currPath, Move Move)
        {
            Nodes = new List<Node>(currPath.Nodes);
            Nodes.Add(Move.NextNode);

            LeafNode = Move.NextNode;
            Cost = currPath.Cost + Move.Cost;
        }

        public void PathLog()
        {
            Console.WriteLine(this.Nodes.Count);
            foreach (var node in Nodes)
            {
                Console.WriteLine($"Path: x: {node.Location[0]}, y: {node.Location[1]} ");
            }
            Console.WriteLine("------------------------------------");
        }
    }
}
