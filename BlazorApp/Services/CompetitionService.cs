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
        public List<Tatami> GetTatamis()
        {
            using(var db = new ApplicationContext())
            {
                return db.Tatamis.ToList();
            }
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
                return db.CompetitionCategories.ToList();
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
            catch(Exception e)
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
    }
}
