using BlazorApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Tatami
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public int AmountOfMatches { get; set; }
        public List<Category> Categories { get; set; }
    }
}
