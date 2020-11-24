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
                double goingEastBias = 0.25;
                double goingSouthBias = 0.25;
                double goingNorthBias = 0.15;
                double goingWestBias = 0.15;
                Console.WriteLine("Locatie: " + request.PartyLocation.X + " , " + request.PartyLocation.Y);
                int locatieX = request.PartyLocation.X;
                int locatieY = request.PartyLocation.Y;
                List<int[]> finish = GetTileTypeLoc(request.Map, TileType.Finish);
                int finishX = finish[0][0];
                int finishY = finish[0][1];
                List<int[]> lijst = GetTileTypeLoc(request.Map, TileType.TreasureChest);
                int aantalChests = lijst.Count();
                if (aantalChests == 0)
                {

                }
                //Console.WriteLine("Const: " + request.PartyMember.GetType);
                if (request.PossibleActions.Contains(TurnAction.Loot))
                {
                    return Task.FromResult(new Turn(TurnAction.Loot));
                }

                if (request.PossibleActions.Contains(TurnAction.Attack))
                {
                    if (request.IsCombat)
                    {
                        if (request.PartyMember.CurrentHealthPoints < 70)
                        {
                            Console.WriteLine("HP: " + request.PartyMember.CurrentHealthPoints);
                            String test = Console.ReadLine();
                            if (request.PossibleActions.Contains(TurnAction.DrinkPotion))
                            {
                                return Task.FromResult(new Turn(TurnAction.DrinkPotion));

                            }
                        }
                    }

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

                if (request.PossibleActions.Contains(TurnAction.WalkNorth) && _random.NextDouble() > (1 - goingNorthBias))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkNorth));
                }
                if (request.PossibleActions.Contains(TurnAction.WalkWest) && _random.NextDouble() > (1 - goingWestBias))
                {
                    return Task.FromResult(new Turn(TurnAction.WalkWest));
                }


                return Task.FromResult(new Turn(request.PossibleActions[_random.Next(request.PossibleActions.Length)]));
            }


        }

    }
    
}