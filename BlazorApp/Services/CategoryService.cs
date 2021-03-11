using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class CategoryService
    {
        IConfiguration configuration;

        public CategoryService(IConfiguration configuration)
        {
            this.configuration = configuration;
            //InitDb();
        }

        private void InitDb()
        {
            string connString = configuration.GetValue<string>("ConnectionString");
        }

        public List<WeightGroup> GetWeightGroups()
        {
            return new List<WeightGroup>()
            {
                new WeightGroup()
                {
                    Name="МУЖ 30-40кг",
                    Sex = "МУЖ",
                    WeightFrom=30,
                    WeightTo=40
                },
                new WeightGroup()
                {
                    Name="МУЖ 40-50кг",
                    Sex = "МУЖ",
                    WeightFrom=40,
                    WeightTo=50
                },new WeightGroup()
                {
                    Name="МУЖ 50-60кг",
                    Sex = "МУЖ",
                    WeightFrom = 50,
                    WeightTo = 60
                },new WeightGroup()
                {
                    Name="ЖЕН 30-40кг",
                    Sex = "ЖЕН",
                    WeightFrom = 30,
                    WeightTo=40
                },new WeightGroup()
                {
                    Name="ЖЕН 40-50кг",
                    Sex = "ЖЕН",
                    WeightFrom=40,
                    WeightTo=50
                },new WeightGroup()
                {
                    Name="ЖЕН 50-60кг",
                    Sex = "ЖЕН",
                    WeightFrom=50,
                    WeightTo=60
                },

            };
        }

        public List<AgeGroup> GetAgeGroups()
        {
            return new List<AgeGroup>()
            {
                new AgeGroup()
                {
                    Age="4-5 лет",
                    AgeFrom=4,
                    AgeTo=5
                },
                new AgeGroup()
                {
                    Age="5-6 лет",
                    AgeFrom=5,
                    AgeTo=6
                },
                new AgeGroup()
                {
                    Age="6-7 лет",
                    AgeFrom=6,
                    AgeTo=7
                },
                new AgeGroup()
                {
                    Age="7-8 лет",
                    AgeFrom=7,
                    AgeTo=8
                },
                new AgeGroup()
                {
                    Age="8-9 лет",
                    AgeFrom=8,
                    AgeTo=9
                }
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
            Id = 1,
            Name = "4-5 лет Девочки -16Кг (8 KYU)1",
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
            Name="4-5 лет Девочки -16Кг (8 KYU)2",
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
            Name="4-5 лет Девочки -16Кг (8 KYU)3",
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
            Name="4-5 лет Девочки -16Кг (8 KYU)4",
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

        public List<string> GetEmails()
        {
            return new List<string>()
            {
                "1@mail.ru",
                "workmail736@gmail.com",
                "andreyrapterror@mail.ru"
            };
        }
    }
}
