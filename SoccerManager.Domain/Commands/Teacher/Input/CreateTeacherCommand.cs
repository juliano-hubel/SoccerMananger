using Flunt.Notifications;
using SoccerManager.Domain.Enums;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Commands.Teacher.Input
{
    public class CreateTeacherCommand : Notifiable, ICommand
    {

        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string  BankAccountName { get; set; }
        public string BankAccountAgency { get; set; }
        public string  BankAccountNumber { get; set; }
        public decimal Earnings { get; set; }
        public DateTime  BithDate { get; set; }
        public EGender Gender { get; set; }
        public string Notes { get; set; }               

        public void Validate()
        {   
            
        }
    }
}
