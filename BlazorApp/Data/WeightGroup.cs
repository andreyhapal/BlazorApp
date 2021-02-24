using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class WeightGroup
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int WeightFrom { get; set; }
        public int WeightTo { get; set; }
    }
}
