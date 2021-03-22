using BlazorApp.Data;
using BlazorApp.Logic.DistributionOfMatches;
using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Logic
{
    public class ShuffleCategoriesForTatami
    {
        public List<Match> Mix(List<Tatami> tatami, List<Match> matches, DivisionParameter parameter = DivisionParameter.DivisionAllowed)
        {
            List<Match> result = new List<Match>();
            List<CompetitionCategory> competitionCategories = null;
            List<AgeGroup> ageGroups = null;

            using (var db = new ApplicationContext())
            {
                competitionCategories = db.CompetitionCategories.ToList();
                ageGroups = db.AgeGroups.ToList();
            }

            //словарь : категория - количество боёв
            Dictionary<int, int> allCategoryAndAmount = DistributionUtil.CreateDictCategoryAmount(matches);
            var categoryIds = matches.Select(x => x.CompetitionGrid.CompetitionCategoryId).Distinct().ToList();

            //Dictionary creation
            List<Dictionary<int, int>> AgesWithCategoryAndAmount = DistributionUtil.GetAgesWithDictionaries(ageGroups, competitionCategories, allCategoryAndAmount, categoryIds);
            var list = AgesWithCategoryAndAmount.OrderByDescending(x => x.Values.Max()).ToList();

            //среднее количество матчей на татами
            var medium = allCategoryAndAmount.Sum(k => k.Value) / tatami.Count + 1;

            switch (parameter)
            {
                case DivisionParameter.DivisionAllowed:
                    {
                        ShuffleWithDivision shuffleWithDiv = new ShuffleWithDivision();
                        result = shuffleWithDiv.Mix(list, medium, tatami, matches);
                        break;
                    }
                case DivisionParameter.DivisionNotAllowed:
                    {
                        ShuffleWithoutDivision shuffleWithoutDiv = new ShuffleWithoutDivision();
                        result = shuffleWithoutDiv.Mix(list, medium, tatami, matches);
                        break;
                    }
                default:
                    {
                        ShuffleWithDivision shuffleWithDiv = new ShuffleWithDivision();
                        result = shuffleWithDiv.Mix(list, medium, tatami, matches);
                        break;
                    }
            }

            return result;
        }


    }
}
