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

        public int GetAmountOfCompetitors(int Id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Competitors.Include(x=>x.CompetitionCategory).Where(x => x.CompetitionCategory.Id == Id).ToList().Count;
            }
        }

        private void InitDb()
        {
            string connString = configuration.GetValue<string>("ConnectionString");
        }

        public List<WeightGroup> GetWeightGroups()
        {
            using (var db = new ApplicationContext())
            {
                return db.WeightGroups.ToList();
            }
        }

        public List<AgeGroup> GetAgeGroups()
        {
            using (var db = new ApplicationContext())
            {
                return db.AgeGroups.ToList();
            }
        }

        public List<Grade> GetGrades()
        {
            using (var db = new ApplicationContext())
            {
                return db.Grades.ToList();
            }
        }

        public List<SportCategoryType> GetTypes()
        {
            using (var db = new ApplicationContext())
            {
                return db.Types.ToList();
            }
        }

        public List<SportCategory> GetCategories()
        {
            using (var db = new ApplicationContext())
            {
                return db.SportCategories.Include(x=>x.AgeGroup).Include(x=>x.WeightGroup).Include(x=>x.Sex).Include(x=>x.Type).ToList();
            }
        }

        public List<Sex> GetSexes()
        {
            using (var db = new ApplicationContext())
            {
                return db.Sexes.ToList();
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
