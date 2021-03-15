using BlazorApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Tatami
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string MatchPrefix { get; set; }

        public List<Match> Matches { get; set; }
        public List<CompetitionCategory> Categories { get; set; }

        [ForeignKey("CompetitionId")]
        public Competition Competition { get; set; }
        public int CompetitionId { get; set; }
    }
}
