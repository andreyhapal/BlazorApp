using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class SportsmenService
    {
        public List<Sportsman> GetSportsmen()
        {
            return new List<Sportsman>()
            {
                new Sportsman()
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
                },
                new Sportsman()
                {
                    Id=2,
                    FirstName="Вадим",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                },
                new Sportsman()
                {
                    Id=3,
                    FirstName="Роман",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                },
                new Sportsman()
                {
                    Id=4,
                    FirstName="Дмитрий",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                },
                new Sportsman()
                {
                    Id=5,
                    FirstName="Филипп",
                    LastName="Иванов",
                    IKO=20012122,
                    BirthDate=DateTime.Parse("07.07.2000"),
                    Age=20,
                    Sex="МУЖ",
                    Grade="1 КЮ",
                    Trainer="Вячеслав Петров",
                    Weight=80,
                },
            };
        }

    }
}
