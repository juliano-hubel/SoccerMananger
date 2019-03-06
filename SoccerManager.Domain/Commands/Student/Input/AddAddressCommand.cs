using Flunt.Notifications;
using Flunt.Validations;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Commands.Student.Input
{
    public class AddAddressCommand : Notifiable , ICommand
    {
        public Guid StudentID { get; set; }
        public string ZipCode { get;  set; }
        public string Street { get;  set; }
        public int Number { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string PhoneNumber { get;  set; }
        public string CellPhoneNumber { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(ZipCode, "ZipCode", "O CEP não pode ser vazio")
                .IsNotNullOrEmpty(Street, "Street", "A rua não pode ser vazia")
                .IsNotNullOrEmpty(Neighborhood, "Neighborhood", "O bairro não pode ser vazio")
                .IsNotNullOrEmpty(City, "City", "A cidade não pode ser vazia")
                .IsNotNullOrEmpty(State, "State", "O Estado não pode ser vazio"));
        }
    }
}
