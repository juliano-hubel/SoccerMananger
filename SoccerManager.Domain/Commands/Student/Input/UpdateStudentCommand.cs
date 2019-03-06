using Flunt.Notifications;
using Flunt.Validations;
using SoccerManager.Domain.Enums;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Commands.Student.Input
{
    public class UpdateStudentCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentRG { get; set; }
        public string StudentCPF { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public string Notes { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherLastName { get; set; }
        public string FatherRG { get; set; }
        public string FatherCPF { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherLastName { get; set; }
        public string MotherRG { get; set; }
        public string MotherCPF { get; set; }
        public decimal PaymentFee { get; set; }
        public int PaymentExpirationDay { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Id, "Id" , "O Id não pode ser nulo") 
                .IsNotNullOrEmpty(StudentFirstName, "StudentFirstName", "O nome do aluno não pode ser vazio")
                .IsNotNullOrEmpty(StudentLastName, "StudentLastName", "O sobrenome do aluno não pode ser vazio")
                .AreNotEquals(BirthDate, DateTime.MinValue, "BirthDate", "A data de nascimento deve ser informada do aluno não pode ser vazio")
                .IsNotNull(Gender, "Gender", "O sexo do aluno não pode ser vazio")
                .IsNotNullOrEmpty(FatherFirstName, "FatherFirstName", "O nome do pai não pode ser vazio")
                .IsNotNullOrEmpty(FatherLastName, "FatherLastName", "O sobrenome do pai não pode ser vazio")
                .IsNotNullOrEmpty(FatherCPF, "FatherCPF", "O CPF do pai não pode ser vazio")
                .IsNotNullOrEmpty(MotherFirstName, "MotherFirstName", "O nome da mãe não pode ser vazio")
                .IsNotNullOrEmpty(MotherLastName, "MotherLastName", "O sobrenome da mãe não pode ser vazio")
                .IsNotNullOrEmpty(MotherCPF, "MotherCPF", "O CPF da mãe não pode ser vazio")
                .IsGreaterThan(PaymentFee, 0, "PaymentFee", "A mensaliade deve ser maior que zero")
                );
        }
    }
}
