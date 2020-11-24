using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTF2020.Contracts;
using HTF2020.Contracts.Enums;
using HTF2020.Contracts.Models;
using HTF2020.Contracts.Models.Adventurers;
using HTF2020.Contracts.Requests;

namespace TheFellowshipOfCode.DotNet.YourAdventure
{
    public class MyAdventure : IAdventure
    {
        private readonly Random _random = new Random();

        public Task<Party> CreateParty(CreatePartyRequest request)
        {
            var party = new Party
            {
                Name = "My Party",
                Members = new List<PartyMember>()
            };

            for (var i = 0; i < request.MembersCount; i++)
            {
                party.Members.Add(new Fighter()
                {
                    Id = i,
                    Name = $"Member {i + 1}",
                    Constitution = 11,
                    Strength = 12,
                    Intelligence = 11
                });
            }

            return Task.FromResult(party);
        }

        public List<int[]> GetTileTypeLoc(Map map, TileType type)
        {
            List <int[]> locations = new List<int[]>();

            for(int i=0; i < map.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < map.Tiles.GetLength(1); j++)
                {
                    if (map.Tiles[i, j].TileType == type)
                    {
                        locations.Add(new int[2] { i, j });
                        Console.WriteLine($"Locations i:{i} j:{j}");
                    }
                }
            }
            return locations;
        } 

        public Task<Turn> PlayTurn(PlayTurnRequest request)
        {
            return PlayToEnd();

            Task<Turn> PlayToEnd()
            {
                return Strategic();
                //return Task.FromResult(request.PossibleActions.Contains(TurnAction.WalkSouth) ? new Turn(TurnAction.WalkSouth) : new Turn(request.PossibleActions[_random.Next(request.PossibleActions.Length)]));
            }


            Task<Turn> Strategic()
            {
                const double goingEastBias = 0.35;
                const double goingSouthBias = 0.25;

                GetTileTypeLoc(request.Map, TileType.TreasureChest);

                

                if (request.PossibleActions.Contains(TurnAction.Loot))
                {
                    return Task.FromResult(new Turn(TurnAction.Loot));
                }

                if (request.PossibleActions.Contains(TurnAction.Attack))
                {
                    return Task.FromResult(new Turn(TurnAction.Attack));
                }

                if (request.PossibleActions.Contains(TurnAction.WalkEast) && _random.NextDouble() > (1 - goingEastBias))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkEast));
                }

                if (request.PossibleActions.Contains(TurnAction.WalkSouth) && _random.NextDouble() > (1 - goingSouthBias))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkSouth));
                }

                return Task.FromResult(new Turn(request.PossibleActions[_random.Next(request.PossibleActions.Length)]));
            }
        }
    }
}