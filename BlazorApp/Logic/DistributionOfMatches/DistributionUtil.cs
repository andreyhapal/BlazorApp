using BlazorApp.Data;
using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Logic.DistributionOfMatches
{
    public static class DistributionUtil
    {
        public static Dictionary<int, int> CreateDictCategoryAmount(List<Match> matches)
        {
            Dictionary<int, int> allCategoryAndAmount = new Dictionary<int, int>();
            var categoryIds = matches.Select(x => x.CompetitionGrid.CompetitionCategoryId).Distinct().ToList();
            for (int i = 0; i < categoryIds.Count; i++)
            {
                allCategoryAndAmount.Add(categoryIds[i], matches.Where(m => m.CompetitionGrid.CompetitionCategoryId == categoryIds[i]).ToList().Count);
            }
            return allCategoryAndAmount;
        }

        public static List<Dictionary<int, int>> GetAgesWithDictionaries(List<AgeGroup> ageGroups, List<CompetitionCategory> competitionCategories, Dictionary<int, int> allCategoryAndAmount, List<int> categoryIds)
        {
            List<Dictionary<int, int>> AgesWithCategoryAndAmount = new List<Dictionary<int, int>>();
            //List<string> competitAges = new List<string>();
            foreach (var age in ageGroups)
            {
                Dictionary<int, int> categoryAmount = new Dictionary<int, int>();
                for (int i = 0; i < categoryIds.Count; i++)
                {
                    var compCat = competitionCategories.FirstOrDefault(c => c.Id == categoryIds[i]);

                    if (age.From == compCat.AgeFrom && age.To == compCat.AgeTo)
                    {
                        categoryAmount.Add(categoryIds[i], allCategoryAndAmount.FirstOrDefault(x => x.Key == categoryIds[i]).Value);
                    }
                }
                if (categoryAmount.Count > 0)
                {
                    //competitAges.Add(age.AgeName);
                    var addit = from entry in categoryAmount orderby entry.Value descending select entry;
                    AgesWithCategoryAndAmount.Add(addit.ToDictionary(x => x.Key, x => x.Value));
                }
            }
            return AgesWithCategoryAndAmount;
        }

        public static void PrintResult(List<Match> result, List<Tatami> tatami)
        {
            Console.WriteLine("Match\t GridId\t Tatami");
            foreach (var match in result)
            {
                Console.WriteLine(match.Id + "\t " + match.CompetitionGridId + "\t " + match.Tatami.Name);
            }
            Console.WriteLine("\nTotal amount of matches - " + result.Count);

            foreach (var t in tatami)
            {
                Console.WriteLine($"{t.Name} " + result.Where(i => i.Tatami.Name.Equals(t.Name)).ToList().Count);
            }
        }
    }
}
