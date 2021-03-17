using BlazorApp.Models;
using BlazorApp.Util;
using System.Linq;

namespace BlazorApp.Services
{
    public class SportClubService
    {
        public SportClub GetSportClub(SportClub sportClub)
        {
            using (var db = new ApplicationContext())
            {
                var club = db.SportClubs.FirstOrDefault(x => x.Name == sportClub.Name && x.Organization == sportClub.Organization);
                if (club == null)
                {
                    return DefaultValues.SportClub;
                }
                else return club;
            }
        }
    }
}
