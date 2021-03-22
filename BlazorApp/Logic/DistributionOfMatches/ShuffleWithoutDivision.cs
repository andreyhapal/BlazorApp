using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Logic.DistributionOfMatches
{
    public class ShuffleWithoutDivision : IDistributor
    {
        public List<Match> Mix(List<Dictionary<int, int>> list, int medium, List<Tatami> tatami, List<Match> matches)
        {
            List<Match> result = new List<Match>();
            int[] tatamiCounter = new int[tatami.Count];

            foreach (var dict in list)
            {
                int sum = dict.Sum(x => x.Value);
                for (int j = 0; j < tatami.Count; j++)
                {
                    if (tatamiCounter[j] + sum > medium && sum < medium && tatamiCounter[j] != tatamiCounter.Min()) continue;
                    else
                    {
                        tatamiCounter[j] += sum;

                        foreach (var category in dict)
                        {
                            var selectedMatches = matches.Where(x => x.CompetitionGrid.CompetitionCategoryId == category.Key).ToList();
                            foreach (var match in selectedMatches)
                            {
                                match.Tatami = tatami[j];
                            }
                            result.AddRange(selectedMatches);
                        }
                        break;
                    }
                }
            }

            return result;
        }
    }
}
