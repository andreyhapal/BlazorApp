using BlazorApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileHelpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [DelimitedRecord(",")]
    public class Competitor:AbstractSportsman
    {

        public int Id { get; set; }

        public int SportsmanId { get; set; }
        [ForeignKey("SportsmanId")]
        public Sportsman Sportsman { get; set; }

        public int CompetitionId { get; set; }
        [ForeignKey("CompetitionId")]
        public Competition Competition { get; set; }

        public CompetitionCategory CompetitionCategory { get; set; }

        [FieldConverter(ConverterKind.Boolean)]
        public bool IsRegistred { get; set; } = false;

        public List<Match> Matches { get; set; }

        public int Level { get; set; }
        public string ClubName { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        public int IKO { get; set; }
        public string RegistrationUrl { get; set; }



        public AgeGroup AgeGroup { get; set; }
        public WeightGroup WeightGroup { get; set; }

    }
}
