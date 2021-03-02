using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class CompetitionService
    {
        public List<Competition> GetCompetitions()
        {
            return new List<Competition>()
            {
                new Competition()
                {
                    Id=1,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=2,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=3,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=4,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=5,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=6,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=7,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="",
                    City="Minsk",
                    Country="Belarus",
                }
            };
        } 
    }
}
