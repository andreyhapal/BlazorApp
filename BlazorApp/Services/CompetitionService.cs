using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class CompetitionService
    {
        public List<Tatami> GetTatamis()
        {
            return new List<Tatami>()
            {
                new Tatami()
                {
                    Name="A",
                    AmountOfMatches=12,
                    Prefix="A-",
                },
                new Tatami()
                {
                    Name="B",
                    AmountOfMatches=24,
                    Prefix="B-",
                },
                new Tatami()
                {
                    Name="C",
                    AmountOfMatches=36,
                    Prefix="C-",
                },
                new Tatami()
                {
                    Name="D",
                    AmountOfMatches=48,
                    Prefix="D-",
                },
                new Tatami()
                {
                    Name="E",
                    AmountOfMatches=50,
                    Prefix="E-",
                }
            };
        }

        public List<Competitor> GetCompetitors()
        {
            return new List<Competitor>()
            {
                new Competitor()
                {
                    Id=1,
                    FirstName="Сергей",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                    IsActive = false,
                    Country = "Belarus",
                    City = "Minsk",
                    StartNumber = 0,
                     Club = "KMS",

                },
                new Competitor()
                {
                    Id=2,
                    FirstName="Сергей",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                    IsActive = false,
                    Country = "Belarus",
                    City = "Minsk",
                    StartNumber = 0,
                     Club = "KMS",
                },
                new Competitor()
                {
                    Id=3,
                    FirstName="Сергей",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                    IsActive = false,
                    Country = "Belarus",
                    City = "Minsk",
                    StartNumber = 0,
                     Club = "KMS",
                },
                new Competitor()
                {
                    Id=4,
                    FirstName="Сергей",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                    IsActive = false,
                    Country = "Belarus",
                    City = "Minsk",
                    StartNumber = 0,
                     Club = "KMS",
                },
                new Competitor()
                {
                    Id=5,
                    FirstName="Сергей",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                    IsActive = false,
                    Country = "Belarus",
                    City = "Minsk",
                    StartNumber = 0,
                     Club = "KMS",
                },
                new Competitor()
                {
                    Id=6,
                    FirstName="Сергей",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                    IsActive = false,
                    Country = "Belarus",
                    City = "Minsk",
                    StartNumber = 0,
                     Club = "KMS",
                },
            };
        }

        public List<Competition> GetCompetitions()
        {
            return new List<Competition>()
            {
                new Competition()
                {
                    Id=1,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="Global Tournament 2021",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=2,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="WWS WWA 2021",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=3,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="Championship 2021",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=4,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="RUSCHAMP 2021",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=5,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="GLOBALIZATION 2021",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=6,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="USASHIP 2021",
                    City="Minsk",
                    Country="Belarus",
                },
                new Competition()
                {
                    Id=7,
                    DateFound = DateTime.Parse("01.01.2020"),
                    Name="MMA 2021",
                    City="Minsk",
                    Country="Belarus",
                }
            };
        }
    }
}
