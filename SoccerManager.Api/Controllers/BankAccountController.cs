using Microsoft.AspNetCore.Mvc;
using SoccerManager.Domain.Commands.BankAccount.Input;
using SoccerManager.Domain.Handlers;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerManager.Api.Controllers
{
    public class BankAccountController : Controller
    {
        private BankAccountHandler _handler;
        public BankAccountController(BankAccountHandler handler)
        {
            _handler = handler;
        }
        
        [HttpPost]
        [Route("BankAccount")]
        public ICommandResult Create([FromBody] CreateBankAccountCommand command)
        {
           return _handler.Handle(command);
        }
    }
}
