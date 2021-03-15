using FileHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Sportsman : AbstractSportsman
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
