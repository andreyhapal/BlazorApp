using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class ApplicationContext:DbContext
    {

        public ApplicationContext()
        {
            Database.EnsureCreated();
            Database.SetCommandTimeout(TimeSpan.FromMinutes(5));
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configFileName = "appsettings.json";

            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile(configFileName, true, true)
              .Build();
            var defaultConnectionString = "Host=localhost;Port=5433;Database=postgres;Username=postgres;Password=12qwasZX";
            
            var appSettingsConnetionStringKey = "ConnectionString";

            //optionsBuilder.LogTo(Console.WriteLine);

            

            if (configuration == null)
                Console.WriteLine($"Configuration file \"{appSettingsConnetionStringKey}\" not found");

            var connectionString = configuration.GetSection(appSettingsConnetionStringKey)?.Value;
            if (string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseNpgsql(defaultConnectionString);
            }
            else
            {
                Console.WriteLine($"DB connection string: {connectionString}");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<SportCategory>()
                .HasIndex(x => x.Name).IsUnique(true);

            modelBuilder.Entity<SportCategory>()
                .HasMany(u => u.Grades)
                    .WithMany(r => r.SportCategories)
                    .UsingEntity(j => j.ToTable("SportCategoriesAndGrades"));

            modelBuilder.Entity<Competition>()
                .HasMany(x => x.Categories);
            modelBuilder.Entity<Competition>()
                .HasMany(x => x.Referees);
            modelBuilder.Entity<Competition>()
               .HasMany(x => x.Tatamis)
               .WithOne(x => x.Competition)
               .HasForeignKey(x => x.CompetitionId);

            modelBuilder.Entity<CompetitionCategory>()
                .HasOne(x => x.CompetitionGrid)
                .WithOne(x => x.CompetitionCategory);

            modelBuilder.Entity<CompetitionCategory>()
                .HasMany(x => x.Competitors);

            modelBuilder.Entity<CompetitionGrid>()
                .HasOne(x => x.CompetitionCategory)
                .WithOne(x => x.CompetitionGrid);

            modelBuilder.Entity<CompetitionGrid>()
                .HasMany(x => x.Matches)
                .WithOne(x => x.CompetitionGrid)
                .HasForeignKey(x => x.CompetitionGridId);

            modelBuilder.Entity<CompetitionGrid>()
                .HasMany(x => x.Nodes)
                .WithOne(x => x.CompetitionGrid)
            .HasForeignKey(x => x.CompetitionGridId);


            modelBuilder.Entity<CompetitionGridNode>()
                .HasOne(x => x.ParentNode)
                .WithMany(x => x.ChildrenNodes)
                .HasForeignKey(x => x.ParentNodeId);

            modelBuilder.Entity<Tatami>()
                .HasMany(x => x.Matches)
                .WithOne(x => x.Tatami)
                .HasForeignKey(x => x.TatamiId);

            modelBuilder.Entity<Tatami>()
                .HasMany(x => x.Categories)
                .WithOne(x => x.Tatami)
                .HasForeignKey(x => x.TatamiId);

            modelBuilder.Entity<Match>()
                .HasMany(x => x.Referees)
                .WithMany(x => x.Matches)
                .UsingEntity(x => x.ToTable("RefereesAndMatches"));

            modelBuilder.Entity<Match>()
                .HasMany(x => x.Competitors)
                .WithMany(x => x.Matches)
                .UsingEntity(x => x.ToTable("CompetitorsAndMatches"));

            modelBuilder.Entity<Competitor>()
                .HasMany(x => x.Matches)
                .WithMany(x => x.Competitors)
                .UsingEntity(x => x.ToTable("CompetitorsAndMatches"));

            modelBuilder.Entity<Competitor>()
                .HasOne(x => x.Competition);

            modelBuilder.Entity<Competitor>()
                .HasOne(x => x.Sportsman);


            modelBuilder.Entity<SportClub>()
                .HasMany(x => x.Trainers)
                .WithOne(x => x.Club);

            modelBuilder.Entity<SportClub>()
                .HasMany(x => x.Sportsmens)
                .WithOne(x => x.SportClub);

            modelBuilder.Entity<Trainer>()
                .HasMany(x => x.Sportsmans)
                .WithOne(x => x.Trainer);

            modelBuilder.Entity<Referee>()
                .HasMany(x => x.Matches)
                .WithMany(x => x.Referees)
                .UsingEntity(x => x.ToTable("RefereesAndMatches"));
        }


        public DbSet<SportClub> SportClubs { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Referee> Referees { get; set; }

        public DbSet<SportCategory> SportCategories { get; set; }

        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<WeightGroup> WeightGroups { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<SportCategoryType> Types { get; set; }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Sportsman> Sportsmens { get; set; }
        public DbSet<CompetitionGrid> CompetitionGrids { get; set; }
        public DbSet<CompetitionGridNode> CompetitionGridNodes { get; set; }
        public DbSet<CompetitionCategory> CompetitionCategories { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Competitor> Competitors { get; set; }

        public DbSet<Tatami> Tatamis { get; set; }
    }
}
