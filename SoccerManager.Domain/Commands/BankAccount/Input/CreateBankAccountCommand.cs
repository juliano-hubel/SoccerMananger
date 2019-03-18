using Flunt.Notifications;
using Flunt.Validations;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Commands.BankAccount.Input
{
    public class CreateBankAccountCommand : Notifiable, ICommand
    {

        public string BankName { get; set; }
        public string Agency { get; set; }
        public string AccountNumber { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(BankName, "BankName", "O nome do banco não poder ser vazio")
                .IsNotNullOrEmpty(Agency, "Agency", "O numero da Agencia não poder ser vazio")
                .IsNotNullOrEmpty(AccountNumber, "AccountNumber", "O numero da conta não poder ser vazio"));
        }
    }
}
