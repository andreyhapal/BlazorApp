using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Util
{
    public static class Converter
    {
        public static CompetitionCategory SportCategoryToCompetitionCategory(SportCategory sportCategory, Competition competition, Tatami tatami)
        {
            CompetitionCategory category = new CompetitionCategory()
            {
                Competition = competition,
                AgeFrom = sportCategory.AgeGroup.From,
                AgeTo = sportCategory.AgeGroup.To,
                WeightFrom = sportCategory.WeightGroup.From,
                WeightTo = sportCategory.WeightGroup.To,
                SportCategoryId = sportCategory.Id,
                Tatami = tatami,
                Name = sportCategory.Type.Name + " " + sportCategory.Sex.Name + " " + sportCategory.AgeGroup.AgeName + " " + sportCategory.WeightGroup.Name
            };
            return category;
        }
    }
}
