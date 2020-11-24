using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowshipOfCode.DotNet.YourAdventure.A_star
{
    class Frontier
    {
        public List<Path> Paths { get; set; }

        public Frontier(Problem problem)
        {
            Paths = new List<Path>();
            Paths.Add(new Path(problem.Start));
        }

        public Path NextPathToExplore()
        {
            int index = 0;
            Path cheapestPath = Paths[index];
            int indexToRemove = index;

            foreach (Path p in Paths)
            {
                if (p.Cost + p.Nodes[p.Nodes.Count - 1].HeuristicValue < cheapestPath.Cost + cheapestPath.Nodes[cheapestPath.Nodes.Count - 1].HeuristicValue)
                {
                    cheapestPath = p;
                    indexToRemove = index;
                }
                index++;
            }
            Console.WriteLine("--------------------------------------------");
            Paths.RemoveAt(indexToRemove);
            return cheapestPath;
        }
        
    }
}
