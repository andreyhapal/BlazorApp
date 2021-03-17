using BlazorApp.Models;
using BlazorApp.Util;
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

        public Sex GetSexByName(string Name)
        {
            using (var db = new ApplicationContext())
            {
                return db.Sexes.First(x => x.Name == Name);
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

        public Grade GetGradeByName(string Name)
        {
            using (var db = new ApplicationContext())
            {
                return db.Grades.First(x => x.Name == Name);
            }
        }

        public SportClub GetSportClub(SportClub sportClub)
        {
            using (var db = new ApplicationContext())
            {
                var club = db.SportClubs.FirstOrDefault(x => x.Name == sportClub.Name && x.Organization == sportClub.Organization);
                if (club == null)
                {
                    return DefaultValues.SportClub;
                }
                else return club;
            }
        }

        public Trainer GetTrainer(Trainer trainer)
        {
            using (var db = new ApplicationContext())
            {
                var Trainer = db.Trainers.FirstOrDefault(x => x.FirstName == trainer.FirstName && x.LastName == trainer.LastName && x.DateOfBirth == trainer.DateOfBirth);
                if (Trainer == null)
                {
                    return DefaultValues.Trainer;
                }
                else return Trainer;
            }
        }
    }
}
