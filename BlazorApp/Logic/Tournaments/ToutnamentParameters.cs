using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiLogic.Tournaments
{
    public class TournamentParameters
    {
        public bool Create3dPlaceMatch { get; set; }

        public IEnumerable<ShuffleCompetitorParameter> ShuffleCompetitorParameters { get; set; }

        public static TournamentParameters Default =>
            new TournamentParameters()
            {
                Create3dPlaceMatch = false,
                ShuffleCompetitorParameters = new List<ShuffleCompetitorParameter>()
                {
                    new ShuffleCompetitorParameter(){Priority= 0, Parameter = ShuffleParameter.Level},
                    new ShuffleCompetitorParameter(){Priority= 0, Parameter = ShuffleParameter.Club},
                    new ShuffleCompetitorParameter(){Priority= 1, Parameter = ShuffleParameter.Region},
                    new ShuffleCompetitorParameter(){Priority= 2, Parameter = ShuffleParameter.Country},
                }
            };
    }

    public class ShuffleCompetitorParameter
    {
        public short Priority { get; set; }

        public ShuffleParameter Parameter { get; set; }
    }

    public enum ShuffleParameter
    {
        Country, Region, Club, Level
    }
}
