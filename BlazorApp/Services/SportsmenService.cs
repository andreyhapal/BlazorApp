using BlazorApp.Models;
using BlazorApp.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public ResponseObject CreateSportsman(Sportsman sportsman)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Sportsmens.Add(sportsman);
                    db.SaveChanges();
                    response.IsSuccess = true;
                }
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ExceptionMessage = e.Message;
            }
            return response;
        }

        public ResponseObject UpdateSportsman(Sportsman sportsman)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Sportsmens.Update(sportsman);
                    db.SaveChanges();
                    response.IsSuccess = true;
                }
            }catch(Exception e)
            {
                response.IsSuccess = false;
                response.ExceptionMessage = e.Message;
            }
            return response;
        }

        public Sportsman GetSportsmanById(int Id)
        {
            Sportsman sportsman = new Sportsman();
            try
            {
                using (var db = new ApplicationContext())
                {
                    sportsman = db.Sportsmens.First(x => x.Id == Id);
                    return sportsman;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sportsman;
        }
    }
}
