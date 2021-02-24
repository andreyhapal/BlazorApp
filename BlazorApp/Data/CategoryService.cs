using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class CategoryService
    {
        public List<string> GetWeightGroups()
        {
            return new List<string>()
            {
                "муж/30-40",
                "жен/30-40",
                "муж/40-50",
                "жен/40-50",
                "муж/50-60",
                "жен/50-60",
                "муж/60-70"
            };
        }

        public List<string> GetAgeGroups()
        {
            return new List<string>()
            {
                "4-5 лет/4-5",
                "5-6 лет/5-6",
                "6-7 лет/6-7",
                "7-8 лет/7-8",
                "8-9 лет/8-9",
                "9-10 лет/9-10"
            };
        }

        public List<string> GetGrades()
        {
            return new List<string>()
            {
                "0 KU",
                "1 KU",
                "2 KU",
                "3 KU",
                "4 KU",
                "5 KU"
            };
        }

        public List<string> GetTypes()
        {
            return new List<string>()
            {
                "Ката",
                "Кумите"
            };
        }

        public List<Category> GetCategories()
        {
            return new List<Category>()
                {
        new Category()
        {
            Id=1,
            Name="4-5 лет Девочки -16Кг (8 KYU)",
            Type = "Кумите",
            Age = "4-5 лет",
            AgeFrom=10,
            AgeTo=15,
            Sex="МУЖ",
            WeightFrom=40,
            WeightTo=50,

        },
        new Category()
        {
             Id=2,
            Name="4-5 лет Девочки -16Кг (8 KYU)",
            Type = "Кумите",
            Age = "4-5 лет",
            AgeFrom=10,
            AgeTo=15,
            Sex="МУЖ",
            WeightFrom=40,
            WeightTo=50
        },
        new Category()
        {
             Id=3,
            Name="4-5 лет Девочки -16Кг (8 KYU)",
            Type = "Кумите",
            Age = "4-5 лет",
            AgeFrom=10,
            AgeTo=15,
            Sex="МУЖ",
            WeightFrom=40,
            WeightTo=50
        },
        new Category()
        {
             Id=4,
            Name="4-5 лет Девочки -16Кг (8 KYU)",
            Type = "Кумите",
            Age = "4-5 лет",
            AgeFrom=10,
            AgeTo=15,
            Sex="МУЖ",
            WeightFrom=40,
            WeightTo=50
        }
    };
        }
    }
}
