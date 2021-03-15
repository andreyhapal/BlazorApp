using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class SportClub
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string Organization { get; set; }

        public List<Trainer> Trainers { get; set; }
        public List<Sportsman> Sportsmens { get; set; }
    }
}
