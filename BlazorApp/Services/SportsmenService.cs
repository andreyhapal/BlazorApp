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
                    sportsman.Grade = db.Grades.FirstOrDefault(x => x.Name == sportsman.Grade.Name);
                    sportsman.Sex = db.Sexes.FirstOrDefault(x => x.Name == sportsman.Sex.Name);
                    sportsman.Trainer = db.Trainers.FirstOrDefault(x => x.FirstName == sportsman.Trainer.FirstName && x.LastName ==sportsman.Trainer.LastName);
                    sportsman.SportClub = db.SportClubs.FirstOrDefault(x => x.Name == sportsman.SportClub.Name);
                    db.Sportsmens.Add(sportsman);
                    db.SaveChanges();
                    response.IsSuccess = true;
                }
            }
            catch (Exception e)
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
                    sportsman.Grade = db.Grades.FirstOrDefault(x => x.Name == sportsman.Grade.Name);
                    sportsman.Sex = db.Sexes.FirstOrDefault(x => x.Name == sportsman.Sex.Name);
                    sportsman.Trainer = db.Trainers.FirstOrDefault(x => x.FirstName == sportsman.Trainer.FirstName && x.LastName == sportsman.Trainer.LastName);
                    sportsman.SportClub = db.SportClubs.FirstOrDefault(x => x.Name == sportsman.SportClub.Name);
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
                    sportsman = db.Sportsmens
                                    .Include(x=>x.SportClub)
                                    .Include(x=>x.Grade)
                                    .Include(x=>x.Sex)
                                    .Include(x=>x.Trainer)
                                    .First(x => x.Id == Id);
                    return sportsman;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sportsman;
        }

        public ResponseObject DeleteSportsman(int Id)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    var sportsman = db.Sportsmens.FirstOrDefault(x => x.Id == Id);
                    if (sportsman != null)
                    {
                        db.Sportsmens.Remove(sportsman);
                        db.SaveChanges();
                    }
                }
                response.IsSuccess = true;
            }catch(Exception e)
            {
                response.IsSuccess = false;
                response.ExceptionMessage = e.Message;
            }
            return response;
        }
    }
}
