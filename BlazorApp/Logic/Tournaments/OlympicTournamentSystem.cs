using BlazorApp.Models;
using SamuraiLogic.Tournaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Logic.Tournaments
{
    public class OlympicTournametSystem : ITournamentSystem
    {
        public List<CompetitionGridNode> CreateGrid(IEnumerable<Competitor> competitors, TournamentParameters tournamentParameters)
        {
            var competitorsCount = competitors.Count();
            var rootNode = CreateGridRecursive(competitorsCount, null, competitors.ToList(), tournamentParameters, null);

            return GetAllNodes(rootNode);
        }

        private List<CompetitionGridNode> GetAllNodes(CompetitionGridNode rootNode)
        {
            List<CompetitionGridNode> retList = new List<CompetitionGridNode>() { rootNode };
            if (rootNode.ChildrenNodes != null)
            {
                retList.AddRange(rootNode.ChildrenNodes);

                foreach (var childNode in rootNode.ChildrenNodes)
                {
                    retList.AddRange(GetAllNodes(childNode));
                }
            }

            return retList;
        }

        private CompetitionGridNode CreateGridRecursive(int competitorsCount, CompetitionGridNode parentNode, List<Competitor> competitors, TournamentParameters tournamentParameters, bool? isLeft, short level = 0)
        {
            var node = new CompetitionGridNode()
            {
                ParentNode = parentNode,
                CompetitorRest = competitorsCount,
                ChildrenNodes = new List<CompetitionGridNode>(),
                IsLeftNode = isLeft,
                NodeLevel = level
            };

            if (competitorsCount == 1)
            {
                var topCompetitor = GetTopLevelCompetitor(competitors);
                node.Competitor = topCompetitor;
                node.CompetitorId = topCompetitor.Id;
                competitors.Remove(topCompetitor);
            }

            else
            {
                node.Match = new Match() { IsThirdPlaceMatch = false, Competitors = new List<Competitor>() };

                if (competitorsCount == 2)
                {
                    var firstCompetitor = GetTopLevelCompetitor(competitors);

                    if (firstCompetitor != null)
                    {
                        node.Match.Competitors.Add(firstCompetitor);
                        var leftNode = new CompetitionGridNode()
                        {
                            ParentNode = node,
                            Competitor = firstCompetitor,
                            CompetitorId = firstCompetitor.Id,
                            CompetitorRest = 1,
                            IsLeftNode = true,
                            NodeLevel = (short)(level + 1)
                        };
                        node.ChildrenNodes.Add(leftNode);
                        competitors.Remove(firstCompetitor);
                    }

                    var secondCompetitor = GetSecondCompetitor(firstCompetitor, competitors, tournamentParameters.ShuffleCompetitorParameters);
                    if (secondCompetitor != null)
                    {
                        node.Match.Competitors.Add(secondCompetitor);
                        var rightNode = new CompetitionGridNode()
                        {
                            ParentNode = node,
                            Competitor = secondCompetitor,
                            CompetitorId = secondCompetitor.Id,
                            CompetitorRest = 1,
                            IsLeftNode = false,
                            NodeLevel = (short)(level + 1)
                        };
                        node.ChildrenNodes.Add(rightNode);
                        competitors.Remove(secondCompetitor);
                    }
                }
                else
                {
                    int leftCompetirosCount = competitorsCount / 2;
                    int rightCompetirosCount = competitorsCount % 2 == 0 ? competitorsCount / 2 : competitorsCount / 2 + 1;

                    node.ChildrenNodes.Add(CreateGridRecursive(leftCompetirosCount, node, competitors, tournamentParameters, true, (short)(level + 1)));
                    node.ChildrenNodes.Add(CreateGridRecursive(rightCompetirosCount, node, competitors, tournamentParameters, false, (short)(level + 1)));
                }
            }

            return node;
        }

        private static Competitor GetTopLevelCompetitor(IEnumerable<Competitor> competitors)
        {
            var maxLevel = competitors.Max(x => x.Level);
            var topCompetitors = competitors.Where(x => x.Level == maxLevel).ToList();
            Random rnd = new Random();
            return topCompetitors[rnd.Next(0, topCompetitors.Count)];
        }

        private static Competitor GetSecondCompetitor(Competitor firstCompetitor, IEnumerable<Competitor> competitors, IEnumerable<ShuffleCompetitorParameter> parameters)
        {
            if (!competitors.Any())
                return null;

            var prevCompetitors = competitors.ToList();
            foreach (var parameter in parameters?.OrderBy(x => x.Priority).ToList())
            {
                var currentCompetitors = prevCompetitors;

                switch (parameter.Parameter)
                {
                    case ShuffleParameter.Level:
                        currentCompetitors = currentCompetitors.Where(x => x.Level == currentCompetitors.Min(x => x.Level)).ToList();
                        break;
                    case ShuffleParameter.Club:
                        currentCompetitors = currentCompetitors.Where(x => x.ClubName != firstCompetitor.ClubName).ToList();
                        break;
                    case ShuffleParameter.Country:
                        currentCompetitors = currentCompetitors.Where(x => x.Country != firstCompetitor.Country).ToList();
                        break;
                    case ShuffleParameter.Region:
                        currentCompetitors = currentCompetitors.Where(x => x.Region != firstCompetitor.Region).ToList();
                        break;
                }

                if (currentCompetitors.Any())
                {
                    prevCompetitors = currentCompetitors;
                }
                else
                {
                    break;
                }
            }

            Random rnd = new Random();
            return prevCompetitors[rnd.Next(0, prevCompetitors.Count)];
        }
    }
}
