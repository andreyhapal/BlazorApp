using BlazorApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<CompetitionCategory> Categories { get; set; }

        public List<Referee> Referees { get; set; }

        public List<Competitor> Competitors { get; set; }

        public List<Tatami> Tatamis { get; set; }

    }
}
