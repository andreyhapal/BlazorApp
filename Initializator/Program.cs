using System;

namespace Initializator
{
    class Program
    {
        static void Main(string[] args)
        {
            DataCreator dataCreataor = new DataCreator();
            dataCreataor.InitDbDefault();

            var competitionId = dataCreataor.CreateCompetition(3);
        }
    }
}
