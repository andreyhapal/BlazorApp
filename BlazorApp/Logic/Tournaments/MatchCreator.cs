using BlazorApp.Models;
using SamuraiLogic.Tournaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Logic.Tournaments
{
    public class MatchCreator
    {
        ITournamentSystem tournamentSystem;
        public MatchCreator(ITournamentSystem tournamentSystem)
        {
            this.tournamentSystem = tournamentSystem;
        }

        public List<CompetitionGridNode> CreateGrid(IEnumerable<Competitor> competitors, TournamentParameters tournamentParameters)
        {
            return tournamentSystem.CreateGrid(competitors, tournamentParameters);
        }
    }
}
