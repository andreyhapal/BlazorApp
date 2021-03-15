using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class CompetitionGridNode
    {
        [Key]
        public int Id { get; set; }

        public int CompetitionGridId { get; set; }
        [ForeignKey("CompetitionGridId")]
        public CompetitionGrid CompetitionGrid { get; set; }

        [ForeignKey("ParentNodeId")]
        public CompetitionGridNode ParentNode { get; set; }
        public int? ParentNodeId { get; set; }

        public List<CompetitionGridNode> ChildrenNodes { get; set; }
        public bool? IsLeftNode { get; set; }

        [ForeignKey("CompetitorId")]
        public Competitor Competitor { get; set; }
        public int? CompetitorId { get; set; }

        public int? Winner { get; set; }

        [ForeignKey("MatchId")]
        public Match Match { get; set; }
        public int? MatchId { get; set; }

        public int? GridMatchNumber { get; set; }
        public int? GlobalMatchNumber { get; set; }

        public int CompetitorRest { get; set; }
        public short NodeLevel { get; set; }
    }
}
