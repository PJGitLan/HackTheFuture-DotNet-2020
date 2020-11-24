using HTF2020.Contracts.Enums;
using HTF2020.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheFellowshipOfCode.DotNet.YourAdventure.A_star;

namespace TheFellowshipOfCode.DotNet.YourAdventure
{
    class AStar
    {
        Map Map;

        Search algoritm = new Search();

        public AStar(Map map, int[] startingPos, int[] goalPos)
        {
            Map = map;
            List<Node> nodes = getNodes(map, goalPos);
            getMoves(nodes);

            Node goal = nodes.Where(n => n.Location[0] == goalPos[0] && n.Location[1] == goalPos[1]).FirstOrDefault();
            Node start = nodes.Where(n => n.Location[0] == 0 && n.Location[1] == 1).FirstOrDefault();
            
            Problem problem = new Problem( //misschien beter maken door nodes te zoeken met zelfde positie
                start,
                goal
                );

            Path solution = algoritm.Find(problem);
            //solution.PathLog();
            
        }

        public List<Node> getNodes(Map map, int[] goalPos)
        {
            List<Node> nodes = new List<Node>();

            for (int i = 0; i < map.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < map.Tiles.GetLength(1); j++)
                {
                    var tileType = map.Tiles[i, j].TileType;
                    if (map.Tiles[i, j].TerrainType == TerrainType.Grass && tileType != TileType.Wall)
                    {
                        int[] loc = { i, j };
                        nodes.Add(new Node(getDistance(loc, goalPos), loc));
                        if (tileType == TileType.Enemy)
                        {
                            nodes[nodes.Count - 1].HeuristicValue += 5;
                        }
                    }
                }
            }
            return nodes;
        }

        public float getDistance(int[] currPos, int[] goalPos)
        {
            return (Math.Abs(currPos[0] - goalPos[0]) + Math.Abs(currPos[1] - goalPos[1]));
        }

        public void getMoves(List<Node> nodes)
        {
            foreach (var node in nodes)
            {
                Node right = nodes.Where(n => n.Location[0] == node.Location[0] + 1 && n.Location[1] == node.Location[1]).FirstOrDefault();

                if (right != null)
                {
                    node.Moves.Add(new Move(right, 1.00f));
                }

                Node left = nodes.Where(n => n.Location[0] == (node.Location[0] - 1) && n.Location[1] == node.Location[1]).FirstOrDefault();

                if (left != null)
                {
                    node.Moves.Add(new Move(left, 1.00f));
                }

                Node down = nodes.Where(n => n.Location[1] == (node.Location[1] + 1 ) && n.Location[0] == node.Location[0]).FirstOrDefault();

                if (down != null)
                {
                    node.Moves.Add(new Move(down, 1.00f));
                }

                Node up = nodes.Where(n => n.Location[1] == (node.Location[1] - 1) && n.Location[0] == node.Location[0]).FirstOrDefault();

                if (up != null)
                {
                    node.Moves.Add(new Move(up, 1.00f));
                }
            }
        }
    }
}
