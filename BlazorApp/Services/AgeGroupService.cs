using BlazorApp.Data;
using BlazorApp.Models;
using BlazorApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Services
{
    public class AgeGroupService
    {
        public List<AgeGroup> GetAgeGroups()
        {
            using (var db = new ApplicationContext())
            {
                return db.AgeGroups.ToList();
            }
        }

        public ResponseObject CreateAgeGroup(AgeGroup ageGroup)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.AgeGroups.Add(ageGroup);
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

        public ResponseObject UpdateAgeGroup(AgeGroup ageGroup)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.AgeGroups.Update(ageGroup);
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

        public void DeleteAgeGroup(int Id)
        {
            using (var db = new ApplicationContext())
            {
                var ageGroup = db.AgeGroups.FirstOrDefault(x => x.Id == Id);
                if (ageGroup != null)
                {
                    db.AgeGroups.Remove(ageGroup);
                    db.SaveChanges();
                }
            }
        }
    }
}
