using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Data
{
    public class CategoryService
    {
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

        public List<Grade> GetGrades()
        {
            using (var db = new ApplicationContext())
            {
                return db.Grades.ToList();
            }
        }

        public Grade GetGradeByName(string Name)
        {
            using (var db = new ApplicationContext())
            {
                return db.Grades.First(x => x.Name == Name);
            }
        }
        public List<SportCategoryType> GetTypes()
        {
            using (var db = new ApplicationContext())
            {
                return db.Types.ToList();
            }
        }
    }
}
