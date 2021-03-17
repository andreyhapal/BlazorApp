using BlazorApp.Models;
using BlazorApp.Util;
using Microsoft.EntityFrameworkCore;
using System;
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
                return db.SportCategories.Include(x => x.AgeGroup).Include(x => x.WeightGroup).Include(x => x.Sex).Include(x => x.Type).ToList();
            }
        }

        public ResponseObject CreateSportCategory(SportCategory category)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.SportCategories.Add(category);
                    db.SaveChanges();
                }
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ExceptionMessage = e.Message;
            }
            return response;
        }

        public ResponseObject UpdateSportCategory(SportCategory category)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Update(category);
                    db.SaveChanges();
                }
                    response.IsSuccess = true;
            }catch(Exception e)
            {
                response.IsSuccess = false;
                response.ExceptionMessage = e.Message;
            }
            return response;
        }

        public void DeleteSportCategory(int Id)
        {
            using (var db = new ApplicationContext())
            {
                var category = db.SportCategories.FirstOrDefault(x => x.Id == Id);
                if (category != null) db.SportCategories.Remove(category);
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
