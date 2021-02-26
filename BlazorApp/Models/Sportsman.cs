using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Sportsman
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IKO { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Grade { get; set; }
        public string Sex { get; set; }
        public string Trainer { get; set; }
    }
}
