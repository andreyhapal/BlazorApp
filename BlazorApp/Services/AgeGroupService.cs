using BlazorApp.Data;
using BlazorApp.Models;
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
    }
}
