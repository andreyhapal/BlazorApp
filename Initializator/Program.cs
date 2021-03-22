using BlazorApp.Models;
using BlazorApp.Util;
using System;

namespace Initializator
{
    class Program
    {
        static void Main(string[] args)
        {
            DataCreator dataCreataor = new DataCreator();
            //dataCreataor.InitDbDefault();

            //var competitionId = dataCreataor.CreateCompetition(3);

            //dataCreataor.ShuffleMatchesBetweenTatamis(1);
            //dataCreataor.MatchNumbering(1);
            dataCreataor.InitCompetitionCategories();
        }
    }
}
