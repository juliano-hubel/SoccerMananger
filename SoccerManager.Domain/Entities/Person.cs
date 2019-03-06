using Flunt.Validations;
using SoccerManager.Domain.Enums;
using SoccerManager.Domain.ValueObjects;
using SoccerManager.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public abstract class Person : Entity
    {
        protected Person() { }

        protected Person(Name name, string email, DateTime birthDate, EGender gender,  string notes, Address address)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            DateEntered = DateTime.Now;
            Notes = notes;
            Address = address;
        }

        public Name Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public EGender Gender { get; private set; }
        public DateTime DateEntered { get; private set; }
        public string Notes { get; private set; }
        public Address Address { get; private set; }
        public int Age => GetAge();


        public void AddAddress(Address address)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(address.ZipCode, "ZipCode", "O CEP não pode ser vazio")
                .IsNotNullOrEmpty(address.Street, "Street", "A rua não pode ser vazia")
                .IsNotNullOrEmpty(address.Neighborhood, "Neighborhood", "O bairro não pode ser vazio")
                .IsNotNullOrEmpty(address.City, "City", "A cidade não pode ser vazia")
                .IsNotNullOrEmpty(address.State, "State", "O Estado não pode ser vazio"));


            Address = address;
        }

        protected void UpdatePerson(Name name, string email, DateTime birthDate, EGender gender, string notes)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Notes = notes;
        }

        private int GetAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.Month < BirthDate.Month ||
                (DateTime.Now.Month == BirthDate.Month &&
                DateTime.Now.Day < BirthDate.Day))
                age--;

            return age;
        }

    }
}
