using Moq;
using NUnit.Framework;
using SoccerManager.Domain.Commands.BankAccount.Input;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Handlers;
using SoccerManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Tests.Handlers
{
    [TestFixture]
    public class BankAccountHandlerTests
    {
        private Mock<IBankAccountRepository> _bankAccountRepository;
        private CreateBankAccountCommand _createBankAccountCommand;
        private BankAccountHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _bankAccountRepository = new Mock<IBankAccountRepository>();
            _handler = new BankAccountHandler(_bankAccountRepository.Object);
            BuidCreateBankAccountCommand();
        }

        private void BuidCreateBankAccountCommand()
        {
            _createBankAccountCommand = new CreateBankAccountCommand();
            _createBankAccountCommand.BankName = "Banco";
            _createBankAccountCommand.Agency = "1234";
            _createBankAccountCommand.AccountNumber = "123456-7";
        }

        [Test]
        public void Handle_CreateBankAccountCommand_CreateAccount()
        {
            var result = _handler.Handle(_createBankAccountCommand);
            Assert.That(result.Success);            
        }

    }
}
