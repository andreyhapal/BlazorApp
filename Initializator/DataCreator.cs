using BlazorApp.Data;
using BlazorApp.Models;
using Initializator.resource;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Initializator
{
    class DataCreator
    {

        public void InitDbDefault()
        {
            using (var db = new ApplicationContext())
            {

                //Создание базовых категорий
                var ages = CreateDefaultAgeGroups();
                var weights = CreateDefaultWeightGroups();
                var grades = CreateDefaultGrades();
                var sexes = CreateDefaultSexes();
                var types = CreateDefaultTypes();

                db.AgeGroups.AddRange(ages);
                db.WeightGroups.AddRange(weights);
                db.Grades.AddRange(grades);
                db.Sexes.AddRange(sexes);
                db.Types.AddRange(types);
                db.SaveChanges();

                //Создание турнирных категорий
                var sportCategories = CreateSportCategories(ages, weights, types, sexes);
                db.SportCategories.AddRange(sportCategories);
                db.SaveChanges();

                //создание клубов, спортсменов и тренеров
                var clubs = CreateDefaultClubs();
                var trainers = CreateDefaultTrainers(grades, sexes, ages, weights);
                var sportsmans = GenerateSportsmans(200, sexes, grades, ages, weights);

                trainers = ShuffleTrainersBetweenClubs(clubs, trainers);
                sportsmans = ShuffleSportsmansBetweenTainers(trainers, sportsmans);

                db.SportClubs.AddRange(clubs);
                db.Trainers.AddRange(trainers);

                db.Sportsmens.AddRange(sportsmans);

                db.SaveChanges();
            }
        }
        private List<SportCategory> CreateSportCategories(List<AgeGroup> ageGroups, List<WeightGroup> weightGroups, List<SportCategoryType> types, List<Sex> sexes)
        {
            var sportCategories = new List<SportCategory>();

            const int n = 4;
            var mCounter = new int[n];
            var mBaseValues = new int[n];

            mCounter[0] = mBaseValues[0] = types.Count;
            mCounter[1] = mBaseValues[1] = sexes.Count;
            mCounter[2] = mBaseValues[2] = ageGroups.Count;
            mCounter[3] = mBaseValues[3] = weightGroups.Count;

            int sportCategoryIdCounter = 1;

            do
            {
                var competitionCategory = new CompetitionCategory() { Name = string.Empty };
                var sportCategory = new SportCategory();
                for (int j = 0; j < n; j++)
                {

                    switch (j)
                    {
                        case 0:
                            competitionCategory.Name += types[mCounter[j] - 1].Name + " ";
                            sportCategory.Type = types[mCounter[j] - 1];
                            break;
                        case 1:
                            var name = sexes[mCounter[j] - 1].Name == "М" ? "Мужчины" : "Жещины";
                            competitionCategory.Name += name + " ";
                            sportCategory.Sex = sexes[mCounter[j] - 1];
                            break;
                        case 2:
                            competitionCategory.Name += ageGroups[mCounter[j] - 1].AgeName + " ";
                            sportCategory.AgeGroup = ageGroups[mCounter[j] - 1];
                            break;
                        case 3:
                            competitionCategory.Name += weightGroups[mCounter[j] - 1].Name + " ";
                            sportCategory.WeightGroup = weightGroups[mCounter[j] - 1];
                            break;
                    }

                    competitionCategory.SportCategoryId = sportCategoryIdCounter;


                }
                sportCategoryIdCounter++;
                competitionCategory.Name = competitionCategory.Name.TrimEnd();
                sportCategory.Name = competitionCategory.Name;

                sportCategories.Add(sportCategory);
            }
            while (DecreaseAray(mCounter, mBaseValues, mCounter.Length - 1));
            return sportCategories;
        }

        private List<Trainer> ShuffleTrainersBetweenClubs(List<SportClub> clubs, List<Trainer> trainers)
        {
            Random rnd = new Random();

            foreach (var trainer in trainers)
            {
                trainer.Club = clubs[rnd.Next(0, clubs.Count - 1)];
            }

            return trainers;
        }

        private List<Sportsman> ShuffleSportsmansBetweenTainers(List<Trainer> trainers, List<Sportsman> sportsmans)
        {
            Random rnd = new Random();
            foreach (var sportsman in sportsmans)
            {
                var trainer = trainers[rnd.Next(0, trainers.Count - 1)];
                sportsman.Trainer = trainer;
                sportsman.SportClub = trainer.Club;
            }

            return sportsmans;
        }

        private bool DecreaseAray(int[] array, int[] baseArrayValues, int lastIndex)
        {
            if (lastIndex < 0)
                return false;

            array[lastIndex] = array[lastIndex] - 1;//уменьшаем последний разряд
            if (array[lastIndex] == 0)
            {
                array[lastIndex] = baseArrayValues[lastIndex];

                return DecreaseAray(array, baseArrayValues, lastIndex - 1); ;
            }
            else
            {
                return true;
            }
        }

        public List<AgeGroup> CreateDefaultAgeGroups()
        {
            return new List<AgeGroup>()
                {
                    new AgeGroup(){ AgeName = "4-5 лет", From = 4, To = 5},
                    new AgeGroup(){ AgeName = "6-7 лет", From = 6, To = 7},
                    new AgeGroup(){ AgeName = "8-9 лет", From = 8, To = 9},
                    new AgeGroup(){ AgeName = "10-11 лет", From = 10, To = 11},
                    new AgeGroup(){ AgeName = "12-13 лет", From = 12, To = 13},
                    new AgeGroup(){ AgeName = "14-15 лет", From = 14, To = 15},
                    new AgeGroup(){ AgeName = "15-17 лет", From = 15, To = 17},
                    new AgeGroup(){ AgeName = "18-25 лет", From = 18, To = 25},
                    new AgeGroup(){ AgeName = "26-30 лет", From = 26, To = 30},
                    new AgeGroup(){ AgeName = "свыше 30 лет", From = 30, To = 0},

                };
        }

        public List<WeightGroup> CreateDefaultWeightGroups()
        {
            return new List<WeightGroup>()
                {

                    new WeightGroup(){ Name = "От 20 До 25",From=20, To = 25 },
                    new WeightGroup(){ Name = "От 26 До 32", From=26, To = 32 },
                    new WeightGroup(){ Name = "От 33 До 40", From=33, To = 40 },
                    new WeightGroup(){ Name = "От 41 До 49", From=41,To = 49 },
                    new WeightGroup(){ Name = "От 50 До 60", From=50, To = 60 },
                    new WeightGroup(){ Name = "От 61 До 70", From=61, To = 70 },
                    new WeightGroup(){ Name = "От 71 До 80", From=71, To = 80 },
                    new WeightGroup(){ Name = "От 81 До 90", From=81, To = 90 },
                    new WeightGroup(){ Name = "От 91 До 100",From=91, To = 100 },
                    new WeightGroup(){ Name = "Свыше 100", From = 101 ,To=0},

                };
        }

        public List<Sex> CreateDefaultSexes()
        {
            return new List<Sex>()
                {
                    new Sex(){Name = "М"},
                    new Sex(){Name = "Ж"}//,
                    //new Sex(){Name = "Смешанная"}
                };
        }

        public List<Grade> CreateDefaultGrades()
        {
            return new List<Grade>()
                {
                    new Grade(){Name ="0 КЮ" },
                    new Grade(){Name ="10 КЮ" },
                    new Grade(){Name ="9 КЮ" },
                    new Grade(){Name ="8 КЮ" },
                    new Grade(){Name ="7 КЮ" },
                    new Grade(){Name ="6 КЮ" },
                    new Grade(){Name ="5 КЮ" },
                    new Grade(){Name ="4 КЮ" },
                    new Grade(){Name ="3 КЮ" },
                    new Grade(){Name ="2 КЮ" },
                    new Grade(){Name ="1 КЮ" },
                    new Grade(){Name ="1 Дан" },
                    new Grade(){Name ="2 Дан" },
                    new Grade(){Name ="3 Дан" },
                    new Grade(){Name ="4 Дан" },
                    new Grade(){Name ="5 Дан" },
                    new Grade(){Name ="6 Дан" },
                    new Grade(){Name ="7 Дан" },
                    new Grade(){Name ="8 Дан" },
                    new Grade(){Name ="9 Дан" },
                    new Grade(){Name ="10 Дан" },
                };
        }

        public List<SportCategoryType> CreateDefaultTypes()
        {
            return new List<SportCategoryType>(){
                    new SportCategoryType(){Name="Кумите" },
                    //new SportCategoryType(){Name="Ката" },
                };
        }


        public List<SportClub> CreateDefaultClubs()
        {
            return new List<SportClub>()
                {
                    new SportClub(){Address="Минск", Name="Клуб Глобал",Organization="Карате ДО",ShortName="Глобал" },
                    new SportClub(){Address ="Минс", Name = "Клуб Минск", Organization = "Карате ДО", ShortName = "Минс" },
                    new SportClub(){Address ="Брест", Name = "Клуб Брест", Organization = "Карате ДО", ShortName = "Брест" },
                    new SportClub(){Address ="Могилев", Name = "Клуб Могилев", Organization = "Карате После", ShortName = "Могилев" },
                    new SportClub(){Address ="Гродно", Name = "Клуб Гродно", Organization = "Карате После", ShortName = "Гродно" },
                    new SportClub(){Address ="Витебск", Name = "Клуб Витебск", Organization = "Карате После", ShortName = "Витебск" },
                };
        }

        public List<Trainer> CreateDefaultTrainers(List<Grade> grades, List<Sex> sexes, List<AgeGroup> ages, List<WeightGroup> weights)
        {
            Random rnd = new Random();

            List<Trainer> trainers = new List<Trainer>()
                {
                    new Trainer()
                    {
                        Age = rnd.Next(20,100),
                        FirstName = "Вадим",
                        LastName="Усов",
                        Grade=grades[rnd.Next(0,grades.Count)],
                        Sex = sexes[rnd.Next(0,sexes.Count)],
                        Weight = rnd.Next(30,150)
                    },
                    new Trainer()
                    {
                        Age = rnd.Next(20,100),
                        FirstName = "Иван",
                        LastName ="Иванов",
                        Grade = grades[rnd.Next(0,grades.Count)],
                        Sex = sexes[rnd.Next(0,sexes.Count)],
                        Weight = rnd.Next(30,150)
                    },
                    new Trainer()
                    {
                        Age = rnd.Next(20,100),
                        FirstName = "Сергей",
                        LastName ="Петров",
                        Grade = grades[rnd.Next(0,grades.Count)],
                        Sex = sexes[rnd.Next(0,sexes.Count)],
                        Weight = rnd.Next(30,150)
                    },
                    new Trainer()
                    {
                        Age = rnd.Next(20,100),
                        FirstName = "Антон",
                        LastName ="Сидоров",
                        Grade = grades[rnd.Next(0,grades.Count)],
                        Sex = sexes[rnd.Next(0,sexes.Count)],
                        Weight = rnd.Next(30,150)
                    },
                    new Trainer()
                    {
                        Age = rnd.Next(20,100),
                        FirstName = "Виктор",
                        LastName ="Пупин",
                        Grade = grades[rnd.Next(0,grades.Count)],
                        Sex = sexes[rnd.Next(0,sexes.Count)],
                        Weight = rnd.Next(30,150)
                    },
                    new Trainer()
                    {
                        Age = rnd.Next(20,100),
                        FirstName = "Дарья",
                        LastName ="Иванова",
                        Grade = grades[rnd.Next(0,grades.Count)],
                        Sex = sexes[rnd.Next(0,sexes.Count)],
                        Weight = rnd.Next(30,150)
                    },
                    new Trainer()
                    {
                        Age = rnd.Next(20,100),
                        FirstName = "Мария",
                        LastName ="Журавлева",
                        Grade = grades[rnd.Next(0,grades.Count)],
                        Sex = sexes[rnd.Next(0,sexes.Count)],
                        Weight = rnd.Next(30,150)
                    },
                };
            return trainers;
        }

        private List<Sportsman> GenerateSportsmans(int sportnsmansCount, List<Sex> sexes, List<Grade> grades, List<AgeGroup> ages, List<WeightGroup> weights)
        {
            List<Sportsman> sportsmans = new List<Sportsman>();
            Random rnd = new Random();

            for (int i = sportnsmansCount; i > 0; i--)
            {
                var names = rnd.Next(0, 2) == 0 ? RussianNames.ManNames : RussianNames.WomanNames;
                sportsmans.Add(
                    new Sportsman()
                    {
                        Sex = sexes[rnd.Next(0, sexes.Count)],
                        Age = rnd.Next(4, 60),
                        FirstName = names[rnd.Next(0, names.Length - 1)],
                        LastName = names[rnd.Next(0, names.Length - 1)],
                        Grade = grades[rnd.Next(0, grades.Count)],
                        Weight = rnd.Next(20, 150),
                    });
            }

            return sportsmans;
        }
        public int CreateCompetition(int tatamiCount = 1)
        {
            using (var db = new ApplicationContext())
            {
                var competition = new Competition() { Name = "Супер турнир", ShortName = "Турнир", StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(2) };
                var competitionCategoies = CreateCompetitionCategoriesFromDb(competition, db.SportCategories.Include(s => s.AgeGroup).Include(s => s.WeightGroup).AsNoTracking().ToList());
                competition.Categories = competitionCategoies;

                var tatamis = new List<Tatami>();
                for (int i = 1; i <= tatamiCount; i++)
                {
                    tatamis.Add(new Tatami() { Categories = competitionCategoies, Competition = competition, Name = $"Татами {i}", MatchPrefix = $"T{i}-" });
                }
                db.Tatamis.AddRange(tatamis);

                competition.Referees = CreateRefereesFromTainers();

                List<Competitor> competitors = new List<Competitor>();
                db.Sportsmens.Include(x => x.Sex).Include(x => x.Grade).ToList().ForEach(x =>
                {
                    var competitor = new Competitor()
                    {
                        Age = x.Age,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Weight = x.Weight,
                        SportsmanId = x.Id,
                        IKO = x.IKO,
                        DateOfBirth = x.DateOfBirth,
                        Sex = x.Sex,
                        Grade = x.Grade,
                        AgeGroup = db.AgeGroups.FirstOrDefault(a => (x.Age >= a.From && x.Age <= a.To && a.To != 0) || (x.Age >= a.From && a.To == 0)),
                        WeightGroup = db.WeightGroups.FirstOrDefault(a => (x.Weight >= a.From && x.Weight <= a.To && a.To != 0) || (x.Weight >= a.From && a.To == 0)),
                    };

                    var competitorSportCategory = db.SportCategories
                        .FirstOrDefault(y => y.AgeGroup.Id == competitor.AgeGroup.Id
                                            && y.Sex.Id == competitor.Sex.Id
                                            && y.WeightGroup.Id == competitor.WeightGroup.Id);

                    var competitionCategory = competitionCategoies.Where(y => y.SportCategoryId == competitorSportCategory.Id).FirstOrDefault();
                    competitor.CompetitionCategory = competitionCategory;
                    competitionCategory.Competitors.Add(competitor);

                    competitors.Add(competitor);
                });

                competition.Competitors = competitors;

                

                db.Competitions.Add(competition);
                db.SaveChanges();

                return competition.Id;
            }
        }

        

        



        private List<Referee> CreateRefereesFromTainers()
        {
            List<Referee> referees = new List<Referee>();

            using (var db = new ApplicationContext())
            {
                var trainers = db.Trainers.AsNoTracking().ToList();
                Random rnd = new Random();
                var l = Enum.GetNames(typeof(ReferreeType)).Length;
                foreach (var trainer in trainers)
                {
                    referees.Add(new Referee()
                    {
                        Age = trainer.Age,
                        FirstName = trainer.FirstName,
                        LastName = trainer.LastName,
                        DateOfBirth = trainer.DateOfBirth,
                        Weight = trainer.Weight,
                        Grade = trainer.Grade,
                        Sex = trainer.Sex,
                        ReferreeType = (ReferreeType)rnd.Next(0, l - 1)
                    });
                }
            }

            return referees;
        }


        private List<CompetitionCategory> CreateCompetitionCategoriesFromDb(Competition competition, List<SportCategory> sportCategories)
        {
            List<CompetitionCategory> categories = new List<CompetitionCategory>();

            foreach (var sportCategory in sportCategories)
            {
                categories.Add(new CompetitionCategory()
                {
                    Competition = competition,
                    Name = sportCategory.Name,
                    WeightFrom = sportCategory.WeightGroup.From,
                    WeightTo = sportCategory.WeightGroup.To,
                    AgeFrom = sportCategory.AgeGroup.From,
                    AgeTo = sportCategory.AgeGroup.To,
                    SportCategoryId = sportCategory.Id,
                    Competitors = new List<Competitor>()
                });
            }

            return categories;
        }
    }
}
