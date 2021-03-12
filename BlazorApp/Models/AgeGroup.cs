using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class AgeGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AgeName { get; set; }

        [Required]
        public int From { get; set; }

        public int To { get; set; }
    }
}
