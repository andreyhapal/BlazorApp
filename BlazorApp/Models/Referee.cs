using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Referee : AbstractSportsman
    {
        [Key]
        public int Id { get; set; }

        public ReferreeType ReferreeType { get; set; }

        public List<Match> Matches { get; set; }
    }

    public enum ReferreeType
    {
        MainReferre, FieldReferre, CornerReferee
    }
}
