using SoccerManager.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public class Address : Entity
    {
        protected Address()
        {

        }

        public Address(string zipCode, string street, int number, string neighborhood, string city, string state,
            string phoneNumber, string cellPhoneNumber)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            PhoneNumber = phoneNumber;
            CellPhoneNumber = cellPhoneNumber;
        }

        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PhoneNumber { get; private set; }
        public string CellPhoneNumber { get; private set; }
    }
}
