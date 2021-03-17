using BlazorApp.Data;
using BlazorApp.Models;
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
    }
}
