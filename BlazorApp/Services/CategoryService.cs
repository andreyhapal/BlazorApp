using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
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
                    From=30,
                    To=40
                },
                new WeightGroup()
                {
                    Name="МУЖ 40-50кг",
                    From=40,
                    To=50
                },new WeightGroup()
                {
                    Name="МУЖ 50-60кг",
                    From = 50,
                    To = 60
                },new WeightGroup()
                {
                    Name="ЖЕН 30-40кг",
                    From = 30,
                    To=40
                },new WeightGroup()
                {
                    Name="ЖЕН 40-50кг",
                    From=40,
                    To=50
                },new WeightGroup()
                {
                    Name="ЖЕН 50-60кг",
                    From=50,
                    To=60
                },

            };
        }

        public List<AgeGroup> GetAgeGroups()
        {

            return new List<AgeGroup>()
            {
                new AgeGroup()
                {
                    AgeName="4-5 лет",
                    From=4,
                    To=5
                },
                new AgeGroup()
                {
                    AgeName="5-6 лет",
                    From=5,
                    To=6
                },
                new AgeGroup()
                {
                    AgeName="6-7 лет",
                    From=6,
                    To=7
                },
                new AgeGroup()
                {
                    AgeName="7-8 лет",
                    From=7,
                    To=8
                },
                new AgeGroup()
                {
                    AgeName="8-9 лет",
                    From=8,
                    To=9
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

        public List<SportCategory> GetCategories()
        {
            using (var db = new ApplicationContext())
            {
                return db.SportCategories.Include(x=>x.AgeGroup).Include(x=>x.WeightGroup).Include(x=>x.Sex).Include(x=>x.Type).ToList();
            }
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
