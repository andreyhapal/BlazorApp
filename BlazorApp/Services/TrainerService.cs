using BlazorApp.Models;
using BlazorApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Services
{
    public class TrainerService
    {
        public Trainer GetTrainer(Trainer trainer)
        {
            using (var db = new ApplicationContext())
            {
                var Trainer = db.Trainers.FirstOrDefault(x => x.FirstName == trainer.FirstName && x.LastName == trainer.LastName && x.DateOfBirth == trainer.DateOfBirth);
                if (Trainer == null)
                {
                    return DefaultValues.Trainer;
                }
                else return Trainer;
            }
        }

        public ResponseObject CreateTrainer(Trainer trainer)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Trainers.Add(trainer);
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

        public ResponseObject UpdateTrainer(Trainer trainer)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.Trainers.Update(trainer);
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

        public void DeleteTrainer(int Id)
        {
            using (var db = new ApplicationContext())
            {
                var trainer = db.Trainers.FirstOrDefault(x => x.Id == Id);
                if (trainer != null)
                {
                    db.Trainers.Remove(trainer);
                    db.SaveChanges();
                }
            }
        }

        public List<Trainer> GetTrainers()
        {
            using (var db = new ApplicationContext())
            {
                return db.Trainers.ToList();
            }
        }
    }
}
