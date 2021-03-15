using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Trainer:AbstractSportsman
    {
        [Key]
        public int Id { get; set; }

        public SportClub Club { get; set; }
        public List<Sportsman> Sportsmans { get; set; }
    }
}
