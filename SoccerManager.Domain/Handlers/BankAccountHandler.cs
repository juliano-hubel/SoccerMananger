using Flunt.Notifications;
using SoccerManager.Domain.Commands.BankAccount.Input;
using SoccerManager.Domain.Commands.BankAccount.Output;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Repositories;
using SoccerManager.Shared.Commands;
using SoccerManager.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Handlers
{
    public class BankAccountHandler : Notifiable,
        IHandler<CreateBankAccountCommand>
    {
        private IBankAccountRepository _bankAccountRepository;

        public BankAccountHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public ICommandResult Handle(CreateBankAccountCommand command)
        {  

            command.Validate();

            if (!command.Valid)
                return new BankAccountCommandResult(false, "Não foi possivel criar uma conta", command.Notifications);


            var bankAccount = new BankAccount(
                command.BankName,
                command.Agency,
                command.AccountNumber);

            AddNotifications(bankAccount);


            if(Invalid)
                return new BankAccountCommandResult(false, "Não foi possivel criar uma conta", command.Notifications);

            _bankAccountRepository.Create(bankAccount);

            return new BankAccountCommandResult(true, "Conta criada com sucesso", command.Notifications);

        }
    }
}
