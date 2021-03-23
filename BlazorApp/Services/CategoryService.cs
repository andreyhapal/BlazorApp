using BlazorApp.Models;
using BlazorApp.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Services
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
            }
            catch (Exception e)
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

        //public ResponseObject CreateRangeCompetitionCategories(List<SportCategory> sportCategories, int competitionId)
        //{
        //    ResponseObject response = new ResponseObject();
        //    List<CompetitionCategory> competitionCategories = new List<CompetitionCategory>();
        //    try
        //    {
        //        using (var db = new ApplicationContext())
        //        {
        //            var competition = db.Competitions.FirstOrDefault(x => x.Id == competitionId);
        //            var tatami = db.Tatamis.FirstOrDefault(x => x.CompetitionId == competitionId);
        //            var existCategories = db.CompetitionCategories.Where(x => x.CompetitionId == competitionId).ToList();
        //            foreach (var category in sportCategories)
        //            {
        //                var newCompetitionCategory = Converter.SportCategoryToCompetitionCategory(category, competition, tatami);
        //                if (existCategories.Contains(newCompetitionCategory)) continue;
        //                else competitionCategories.Add(newCompetitionCategory);
        //            }

        //            db.CompetitionCategories.AddRange(competitionCategories);
        //            db.SaveChanges();
        //            response.IsSuccess = true;
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        response.IsSuccess = false;
        //        response.ExceptionMessage = e.Message;
        //    }
        //    return response;
        //}


        public List<Sex> GetSexes()
        {
            using (var db = new ApplicationContext())
            {
                return db.Sexes.ToList();
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

        public SportCategory GetSportCategoryById(int Id)
        {
            using (var db = new ApplicationContext())
            {
                return db.SportCategories
                    .Include(x=>x.Sex)
                    .Include(x=>x.AgeGroup)
                    .Include(x=>x.WeightGroup)
                    .Include(x=>x.Type)
                    .FirstOrDefault(x => x.Id == Id);
            }
        }
    }
}
