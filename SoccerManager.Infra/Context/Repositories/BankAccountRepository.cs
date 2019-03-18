using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Repositories;
using SoccerManager.Infra.Context.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerManager.Infra.Context.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private SoccerManagerDataContext _context;
        public BankAccountRepository(SoccerManagerDataContext context)
        {
            _context = context;
        }

        public void Create(BankAccount bankAccount)
        {
            _context.BankAccounts.Add(bankAccount);
            _context.SaveChanges();
        }
    }
}
