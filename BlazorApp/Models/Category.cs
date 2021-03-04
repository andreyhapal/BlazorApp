using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Age { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public string Sex { get; set; }
        public int WeightFrom { get; set; }
        public int WeightTo { get; set; }
        public int NumberOfCompetitors{get;set;}
    }
}
