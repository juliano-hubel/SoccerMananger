using SoccerManager.Shared.Entities;

namespace SoccerManager.Domain.Entities
{
    public class BankAccount : Entity
    {
        protected BankAccount(){}

        public BankAccount(string bankName, string agency, string accountNumber)
        {
            BankName = bankName;
            Agency = agency;
            AccountNumber = accountNumber;
        }

        public string BankName { get; private set; }
        public string Agency { get; private set; }
        public string AccountNumber { get; private set; }
    }
}
