using Flunt.Notifications;
using Flunt.Validations;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Commands.Student.Input
{
    public class AddHealthCommand : Notifiable, ICommand
    {

        public Guid StudentID { get; set; }
        public decimal Height { get;  set; }
        public decimal Weight { get;  set; }
        public string BloodPressure { get;  set; }
        public string Allergies { get;  set; }
        public string Disabilities { get;  set; }
        public string Notes { get;  set; }

        public void Validate()
        {
            AddNotifications(
                    new Contract()
                    .IsGreaterThan(Height, 0, "Height", "A altura deve ser maior que zero")
                    .IsGreaterThan(Weight, 0, "Weight", "O peso deve ser maior que zero"));

        }
    }
}
