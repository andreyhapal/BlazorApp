using BlazorApp.Models;
using BlazorApp.Util;
using System.Linq;

namespace BlazorApp.Services
{
    public class TrainerService
    {
        public Trainer GetTrainer(Trainer trainer)
        {
            using (var db = new ApplicationContext())
            {
                var Trainer = db.Trainers.FirstOrDefault(x => x.FirstName == trainer.FirstName && x.LastName == trainer.LastName && x.DateOfBirth == trainer.DateOfBirth);
                if (Trainer == null)
                {
                    return DefaultValues.Trainer;
                }
                else return Trainer;
            }
        }
    }
}
