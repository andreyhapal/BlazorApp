using BlazorApp.Models;
using BlazorApp.Util;
using System;

namespace Initializator
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataCreator dataCreataor = new DataCreator();
            //dataCreataor.InitDbDefault();

            //var competitionId = dataCreataor.CreateCompetition(3);

            using (var db = new ApplicationContext())
            {
                db.SportClubs.Add(DefaultValues.SportClub);
                db.Trainers.Add(DefaultValues.Trainer);
                db.SaveChanges();
            }
        }
    }
}
