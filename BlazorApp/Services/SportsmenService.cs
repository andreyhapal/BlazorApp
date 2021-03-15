using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class SportsmenService
    {
        public List<Sportsman> GetSportsmen()
        {
            using (var db = new ApplicationContext())
            {
                var c = db.Sportsmens
                        .Include(x => x.Grade)
                        .Include(x => x.Sex)
                        .Include(x=>x.SportClub)
                        .Include(x=>x.Trainer)
                        .ToList();
                return c;
            }
        }
    }
}
