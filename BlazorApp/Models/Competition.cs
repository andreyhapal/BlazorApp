using BlazorApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateFound { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public List<Sportsman> Competitors { get; set; } = new List<Sportsman>();
        public List<Category> Categories { get; set; } = new List<Category>();
        
    }
}
