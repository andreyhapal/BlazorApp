using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorApp.Services
{
    public class CompetitorService
    {
        public int GetAmountOfCompetitors(int Id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Competitors.Include(x => x.CompetitionCategory).Where(x => x.CompetitionCategory.Id == Id).ToList().Count;
            }
        }
    }
}
