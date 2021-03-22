using BlazorApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Logic
{
    public class NumberingOfMatches
    {
        public List<CompetitionGridNode> SetMatchesGridNumber(List<CompetitionGridNode> nodes)
        {
            foreach (var group in nodes.GroupBy(x => x.CompetitionGridId).Select(x => new { gridId = x.Key, nodes = x.Select(m => m) }).ToList())
            {
                int i = 1;
                foreach (var gridNode in group.nodes.OrderByDescending(x => x.NodeLevel).ThenBy(x => x.ParentNodeId).ThenBy(x => x.CompetitorRest))
                {
                    gridNode.GridMatchNumber = gridNode.Match.GridMatchNumber = i++;
                }
            }

            return nodes;
        }

        public List<CompetitionGridNode> SetMatchesGlobalNumber(List<CompetitionGridNode> nodes)
        {
            int i = 1;
            foreach (var group in nodes.GroupBy(x => x.Match.Tatami).Select(x => new { tatami = x.Key, nodes = x.Select(m => m) }).ToList())
            {
                foreach (var gridNode in group.nodes.OrderByDescending(x => x.NodeLevel)
                    .ThenBy(x => x.CompetitionGrid.CompetitionCategory.Name)
                    .ThenBy(x => x.GridMatchNumber))
                {
                    gridNode.GlobalMatchNumber = gridNode.Match.GlobalMatchNumber = i;//$"{group.tatami.MatchPrefix}{i}";
                    i++;
                }
            }

            return nodes;
        }

    }
}
