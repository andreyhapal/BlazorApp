using BlazorApp.Models;
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

        public List<Competitor> GetCompetitors()
        {
            using (var db = new ApplicationContext())
            {
                var c = db.Competitors
                            .Include(x=>x.Competition)
                            .Include(x=>x.CompetitionCategory)
                            .Include(x=>x.Sex)
                            .Include(x=>x.Grade)
                            .ToList();
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
    }
}
