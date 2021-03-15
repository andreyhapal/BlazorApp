using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Util
{
    [DelimitedRecord(",")]
    public class SportsmanCSV
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IKO { get; set; }
        [FieldConverter(ConverterKind.Date, "dd.MM.yyyy")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public string Grade { get; set; }
        public string Sex { get; set; }
        public string Trainer { get; set; }
        [FieldConverter(ConverterKind.Boolean)]
        public bool IsRegistered { get; set; }
        
    }
}
