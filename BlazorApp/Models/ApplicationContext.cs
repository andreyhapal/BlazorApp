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

            modelBuilder.Entity<Competition>()
                .HasMany(x => x.Categories);
        }


        public DbSet<SportCategory> SportCategories { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<WeightGroup> WeightGroups { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<SportCategoryType> Types { get; set; }
    }
}
