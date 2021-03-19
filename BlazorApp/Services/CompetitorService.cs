using BlazorApp.Models;
using BlazorApp.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Services
{
    public class CompetitorService
    {
        public List<Competitor> GetCompetitorsInCategory(CompetitionCategory category)
        {
            using (var db = new ApplicationContext())
            {
                return db.Competitors.Include(x => x.CompetitionCategory).Where(x => x.CompetitionCategory.Name == category.Name).ToList();
            }
        }

        public int GetAmountOfCompetitors(int Id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Competitors.Include(x => x.CompetitionCategory).Where(x => x.CompetitionCategory.Id == Id).ToList().Count;
            }
        }

        public List<Competitor> GetCompetitors(int competitionId)
        {
            using (var db = new ApplicationContext())
            {
                var c = db.Competitors
                            .Include(x => x.Competition)
                            .Include(x => x.CompetitionCategory)
                            .Include(x => x.Sex)
                            .Include(x => x.Grade)
                            .Where(x => x.CompetitionId == competitionId)
                            .ToList();
                return c;
            }
        }

        public ResponseObject CreateCompetitor(Competitor competitor, int competitionId)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    competitor.Grade = db.Grades.FirstOrDefault(x => x.Name == competitor.Grade.Name);
                    competitor.Sex = db.Sexes.FirstOrDefault(x => x.Name == competitor.Sex.Name);
                    competitor.AgeGroup = db.AgeGroups.FirstOrDefault(a => (competitor.Age >= a.From && competitor.Age <= a.To && a.To != 0) || (competitor.Age >= a.From && a.To == 0));
                    competitor.WeightGroup = db.WeightGroups.FirstOrDefault(a => (competitor.Weight >= a.From && competitor.Weight <= a.To && a.To != 0) || (competitor.Weight >= a.From && a.To == 0));
                    var sportCategory = db.SportCategories
                                            .Include(x => x.AgeGroup)
                                            .Include(x => x.WeightGroup)
                                            .Include(x => x.Sex)
                                            .Include(x => x.Type)
                                            .FirstOrDefault(x => x.AgeGroup.Id == competitor.AgeGroup.Id && x.WeightGroup.Id == competitor.WeightGroup.Id && x.Sex.Id == competitor.Sex.Id);
                    var newCompetitionCategory = db.CompetitionCategories.FirstOrDefault(x => x.SportCategoryId == sportCategory.Id && x.CompetitionId==competitionId);
                    if (newCompetitionCategory != null) competitor.CompetitionCategory = newCompetitionCategory;
                    else
                    {
                        CompetitionCategory category = new CompetitionCategory()
                        {
                            Competition = db.Competitions.FirstOrDefault(x => x.Id == competitionId),
                            AgeFrom = sportCategory.AgeGroup.From,
                            AgeTo = sportCategory.AgeGroup.To,
                            WeightFrom = sportCategory.WeightGroup.From,
                            WeightTo = sportCategory.WeightGroup.To,
                            SportCategoryId = sportCategory.Id,
                            Tatami = db.Tatamis.FirstOrDefault(),
                            Name = sportCategory.Type.Name + " " + sportCategory.Sex.Name + " " + sportCategory.AgeGroup.AgeName + " " + sportCategory.WeightGroup.Name
                        };
                        db.CompetitionCategories.Add(category);
                        db.SaveChanges();
                        competitor.CompetitionCategory = category;
                    }
                    competitor.Competition = db.Competitions.FirstOrDefault(x => x.Id == competitionId);
                    db.Competitors.Add(competitor);
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

        public ResponseObject UpdateCompetitor(Competitor competitor)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Competitors.Update(competitor);
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

        public void DeleteCompetitor(int Id)
        {
            using (var db = new ApplicationContext())
            {
                var competitor = db.Competitors.FirstOrDefault(x => x.Id == Id);
                db.Competitors.Remove(competitor);
                db.SaveChanges();
            }
        }

        public ResponseObject AddRangeCompetitors(List<Competitor> competitors, int Id)
        {
            ResponseObject response = new ResponseObject();
            return response;
        }
    }
}
