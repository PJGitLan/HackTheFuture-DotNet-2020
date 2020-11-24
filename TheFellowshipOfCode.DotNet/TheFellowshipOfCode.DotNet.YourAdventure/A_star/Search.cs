using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowshipOfCode.DotNet.YourAdventure.A_star
{
    class Search
    {
        public Path Find(Problem problem)
        {
            Frontier frontier = new Frontier(problem);
            List<Node> exploredItems = new List<Node>();

            while (true)
            {
                if (frontier.Paths.Count == 0)
                {
                    return null; //geen resultaat
                }

                Path pathToExplore = frontier.NextPathToExplore();
                exploredItems.Add(pathToExplore.LeafNode);

                foreach (Move move in pathToExplore.LeafNode.Moves)
                {
                    Node childnode = move.NextNode;

                    Path pathAfterFollowingAction = new Path(pathToExplore, move);
                    //pathAfterFollowingAction.DebugLog();

                    if (problem.GoalReached(pathAfterFollowingAction))
                    {
                        return pathAfterFollowingAction;
                    }
                    else
                    {
                        frontier.Paths.Add(pathAfterFollowingAction);
                    }
                }


            }
        }
    }
    }
}
