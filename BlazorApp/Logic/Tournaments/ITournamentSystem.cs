using BlazorApp.Models;
using SamuraiLogic.Tournaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Logic.Tournaments
{
    public interface ITournamentSystem
    {
        public List<CompetitionGridNode> CreateGrid(IEnumerable<Competitor>competitors, TournamentParameters tournamentParameters);
    }
}
