using BlazorApp.Models;
using BlazorApp.Util;
using System;
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

        public ResponseObject CreateSportClub(SportClub sportClub)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.SportClubs.Add(sportClub);
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

        public ResponseObject UpdateSportClub(SportClub sportClub)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                using (var db = new ApplicationContext())
                {
                    db.SportClubs.Update(sportClub);
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

        public void DeleteSportClub(int Id)
        {
            using (var db = new ApplicationContext())
            {
                var club = db.SportClubs.FirstOrDefault(x => x.Id == Id);
                if (club != null)
                {
                    db.SportClubs.Remove(club);
                    db.SaveChanges();
                }
            }
        }
    }
}
