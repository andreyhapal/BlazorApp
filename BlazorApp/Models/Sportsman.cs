using FileHelpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class Sportsman : AbstractSportsman, ICloneable
    {
        [Key]
        public int Id { get; set; }
        public int IKO { get; set; }

        public int SportClubId { get; set; }
        [ForeignKey("SportClubId")]
        public SportClub SportClub { get; set; }

        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; }

        public object Clone()
        {
            return new Sportsman()
            {
                Id = this.Id,
                IKO = this.IKO,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Weight = this.Weight,
                Age =this.Age,
                DateOfBirth = this.DateOfBirth,
                Grade = this.Grade,
                Sex = this.Sex,
                SportClub = this.SportClub,
                Trainer = this.Trainer        
            };
        }
    }

    public abstract class AbstractSportsman
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        [FieldConverter(ConverterKind.Date, "dd.MM.yyyy")]
        public DateTime DateOfBirth { get; set; }
        public Grade Grade { get; set; }
        public Sex Sex { get; set; }
    }
}
