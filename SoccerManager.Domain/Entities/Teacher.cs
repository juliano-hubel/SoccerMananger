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
            Password = EncryptPassword(password);
            BankAccount = bankAccount;
            Earnings = earnings;
        }

        public string Password { get; private set; }        
        public BankAccount BankAccount { get; private set; }
        public decimal Earnings { get; private set; }

        public bool Authenticate(string email, string password)
        {
            if (Email == email && Password == EncryptPassword(password))
                return true;

            AddNotification("Email", "Email ou senha inválidos");
            return false;
        }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
