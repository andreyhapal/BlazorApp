using BlazorApp.Data;
using BlazorApp.Models;
using BlazorApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Services
{
    public class WeightGroupService
    {
        public List<WeightGroup> GetWeightGroups()
        {
            using (var db = new ApplicationContext())
            {
                return db.WeightGroups.ToList();
            }
        }

        public ResponseObject CreateWeightGroup(WeightGroup weightGroup)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.WeightGroups.Add(weightGroup);
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

        public ResponseObject UpdateWeightGroup(WeightGroup weightGroup)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.WeightGroups.Update(weightGroup);
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

        public void DeleteWeightGroup(int Id)
        {
            using (var db = new ApplicationContext())
            {
                var weightGroup = db.WeightGroups.FirstOrDefault(x => x.Id == Id);
                if (weightGroup != null)
                {
                    db.WeightGroups.Remove(weightGroup);
                    db.SaveChanges();
                }
            }
        }

        public bool ExistWeightGroup(WeightGroup weightGroup)
        {
            using (var db = new ApplicationContext())
            {
                var result = db.WeightGroups.FirstOrDefault(x => x.From == weightGroup.From && x.To == weightGroup.To);
                if (result != null) return true;
                else return false;
            }
        }
    }
}
