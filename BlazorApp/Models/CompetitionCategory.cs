using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class CompetitionCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int WeightFrom { get; set; }
        public int WeightTo { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }


        public List<Competitor> Competitors { get; set; }

        public CompetitionGrid CompetitionGrid { get; set; }

        public int SportCategoryId { get; set; }

        [ForeignKey("CompetitionId")]
        public Competition Competition { get; set; }
        public int CompetitionId { get; set; }

        [ForeignKey("TatamiId")]
        public Tatami Tatami { get; set; }
        public int TatamiId { get; set; }
    }
}
