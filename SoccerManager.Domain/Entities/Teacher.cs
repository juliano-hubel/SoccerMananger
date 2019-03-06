using SoccerManager.Domain.Enums;
using SoccerManager.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public class Teacher : Person
    {
        protected Teacher(){}
        public Teacher(string password, BankAccount bankAccount, decimal earnings,
            Name name, string email, DateTime birthDate, EGender gender, string notes, Address address)
            : base(name, email, birthDate, gender, notes, address)
        {
            Password = password;
            BankAccount = bankAccount;
            Earnings = earnings;
        }

        public string Password { get; private set; }        
        public BankAccount BankAccount { get; private set; }
        public decimal Earnings { get; private set; }
    }
}
