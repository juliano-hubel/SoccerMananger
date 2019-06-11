using SoccerManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Queries
{
    public class TeacherQueryResult
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public string Notes { get; set; }
        public string ZipCode { get;  set; }
        public string Street { get;  set; }
        public int Number { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string PhoneNumber { get;  set; }
        public string CellPhoneNumber { get;  set; }
        public string BankName { get;  set; }
        public string BankAgency { get;  set; }
        public string BankAccountNumber { get;  set; }
        public decimal Earnings { get;  set; }

    }
}
