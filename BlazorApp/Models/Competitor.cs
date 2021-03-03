using BlazorApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileHelpers;

namespace BlazorApp.Models
{
    [DelimitedRecord(",")]
    public class Competitor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IKO { get; set; }
        [FieldConverter(ConverterKind.Date, "dd.MM.yyyy")]
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Grade { get; set; }
        public string Sex { get; set; }
        public string Trainer { get; set; }
        [FieldConverter(ConverterKind.Boolean)]
        public bool IsActive { get; set; }
        public string Category { get; set; }
        public int StartNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Club { get; set; }

    }
}
