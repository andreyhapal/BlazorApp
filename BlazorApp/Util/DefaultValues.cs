using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Util
{
    public class DefaultValues
    {
        public static SportClub SportClub { get; } = new SportClub()
        {
            Name = "",
            Organization="",
            ShortName="",
            Address="",
        };

        public static Trainer Trainer { get; } = new Trainer()
        {
            FirstName = "",
            LastName = "",
            DateOfBirth = DateTime.Parse("01.01.0001")
        };
    }
}
