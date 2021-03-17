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
        public int GetAmountOfCompetitors(int Id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Competitors.Include(x => x.CompetitionCategory).Where(x => x.CompetitionCategory.Id == Id).ToList().Count;
            }
        }

        public List<Competitor> GetCompetitors()
        {
            using (var db = new ApplicationContext())
            {
                var c = db.Competitors
                            .Include(x => x.Competition)
                            .Include(x => x.CompetitionCategory)
                            .Include(x => x.Sex)
                            .Include(x => x.Grade)
                            .ToList();
                return c;
            }
        }

        public ResponseObject CreateCompetitor(Competitor competitor)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Competitors.Add(competitor);
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
            }catch(Exception e)
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
            }
        }
    }
}
