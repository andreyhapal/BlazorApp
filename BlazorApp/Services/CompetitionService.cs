using BlazorApp.Data;
using BlazorApp.Models;
using BlazorApp.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class CompetitionService
    {
        public ResponseObject CreateCompetitionCategoriesRange(List<SportCategory> sportCategories, int competitionId)
        {
            List<CompetitionCategory> CompetitionCategories = new List<CompetitionCategory>();
            List<AgeGroup> newAgeGroups = new List<AgeGroup>();
            List<WeightGroup> newWeightGroups = new List<WeightGroup>();
            ResponseObject response = new ResponseObject();
            //try
            //{
                AgeGroupService ageService = new AgeGroupService();
                WeightGroupService weightService = new WeightGroupService();
                using (var db = new ApplicationContext())
                {
                    var competition = db.Competitions.FirstOrDefault(x => x.Id == competitionId);
                    var tatami = db.Tatamis.FirstOrDefault(x => x.CompetitionId == competitionId);
                    var existCategories = db.CompetitionCategories.Where(x => x.CompetitionId == competitionId).ToList();

                    foreach (var category in sportCategories)
                    {
                        if (ageService.ExistAgeGroup(category.AgeGroup))
                        {
                            category.AgeGroup = db.AgeGroups.FirstOrDefault(x => x.From == category.AgeGroup.From && x.To == category.AgeGroup.To);
                        }
                        else
                        {
                            db.AgeGroups.Add(category.AgeGroup);
                            db.SaveChanges();
                        }

                        if (weightService.ExistWeightGroup(category.WeightGroup))
                        {
                            category.WeightGroup = db.WeightGroups.FirstOrDefault(x => x.From == category.WeightGroup.From && x.To == category.WeightGroup.To);
                        }
                        else
                        {
                            db.WeightGroups.Add(category.WeightGroup);
                            db.SaveChanges();
                        }
                    category.Sex = db.Sexes.FirstOrDefault(x => x.Name == category.Sex.Name);
                    category.Type = db.Types.FirstOrDefault(x => x.Name == category.Type.Name);
                        string sex = category.Sex.Name=="М" ? "Мужчины" : "Женщины";
                        category.Name = category.Type.Name + " " + sex + " " + category.AgeGroup.From + "-" + category.AgeGroup.To + " лет От " + category.WeightGroup.From + " До " + category.WeightGroup.To;
                        var objId = db.SportCategories.FirstOrDefault(x => x.Name == category.Name);
                        if (objId != null)
                        {
                            category.Id = objId.Id;
                        }
                        if (db.SportCategories.FirstOrDefault(x => x.Id == category.Id) == null)
                        {
                            db.SportCategories.Add(category);
                            db.SaveChanges();
                        }
                        var newCategory = Converter.SportCategoryToCompetitionCategory(category, competition, tatami);
                        CompetitionCategories.Add(newCategory);
                    }


                    db.CompetitionCategories.AddRange(CompetitionCategories);
                    db.SaveChanges();
                }
                response.IsSuccess = true;
            //}
            //catch(Exception e)
            //{
            //    response.IsSuccess = false;
            //    response.ExceptionMessage = e.Message;
            //}
            return response;
        }


        public List<Tatami> GetTatamis(int Id)
        {
            using(var db = new ApplicationContext())
            {
                return db.Tatamis.Where(x=>x.CompetitionId==Id).ToList();
            }
        }

        public ResponseObject CreateTatami(Tatami tatami, int Id)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    tatami.Competition = db.Competitions.FirstOrDefault(x => x.Id == Id);
                    db.Tatamis.Add(tatami);
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

        public ResponseObject EditTatami(Tatami tatami)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Tatamis.Update(tatami);
                    db.SaveChanges();
                }
                    response.IsSuccess = true;
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ExceptionMessage = e.Message;
            }
            return response;
        }

        public List<Referee> GetReferees()
        {
            using (var db = new ApplicationContext())
            {
                var c = db.Referees.Include(x=>x.Grade).ToList();
                return c;
            }
        }

        public List<Competition> GetCompetitions()
        {
            using (var db = new ApplicationContext())
            {
                return db.Competitions.ToList();
            }
        }
        
        public List<CompetitionCategory> GetCompetitionCategories(int Id)
        {
            using (var db = new ApplicationContext())
            {
                return db.CompetitionCategories.Where(x=>x.CompetitionId==Id).ToList();
            }
        }

        public ResponseObject CreateCompetition(Competition competition)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Competitions.Add(competition);
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

        public ResponseObject EditCompetition(Competition competition)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Competitions.Update(competition);
                    db.SaveChanges();
                }
                response.IsSuccess = true;
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ExceptionMessage = e.Message;
            }
            return response;
        }

        public void DeleteCompetition(int Id)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    var competition = db.Competitions.FirstOrDefault(x => x.Id == Id);
                    if (competition != null)
                    {
                        db.Competitions.Remove(competition);
                        db.SaveChanges();
                    }
                }
                    response.IsSuccess = true;
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ExceptionMessage = e.Message;
            }
        }

        public Competition GetCompetitionById(int Id)
        {
            using (var db = new ApplicationContext())
            {
                var comp = db.Competitions.FirstOrDefault(x => x.Id == Id);
                if (comp != null)
                {
                    return comp;
                }
                else return new Competition();
            }
        }

        public string GetRefereeCompetitions(int Id)
        {
            using (var db = new ApplicationContext())
            {
                var compet = db.Competitions
                                .Include(x => x.Referees)
                                .Where(x => x.Referees.Where(x => x.Id == Id).ToList().Count > 0)
                                .ToList();
                string result = "";
                foreach(var competition in compet)
                {
                    result += competition.Name + "\n";
                }
                return result;

            }
        }

        public List<Match> GetMatches()
        {
            using (var db = new ApplicationContext())
            {
                return db.Matches.ToList();
            }
        }

        public ResponseObject RemoveCompetitionCategoriesRange(List<int> Ids)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    foreach(var id in Ids)
                    {
                        var objectForRemove = db.CompetitionCategories.FirstOrDefault(x => x.Id == id);
                        if (objectForRemove != null)
                        {
                            db.CompetitionCategories.Remove(objectForRemove);
                            db.SaveChanges();
                        }
                    }
                }
                response.IsSuccess = true;
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ExceptionMessage = e.Message;
            }
            return response;
        }
    }
}
