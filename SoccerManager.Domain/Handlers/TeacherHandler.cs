using Flunt.Notifications;
using SoccerManager.Domain.Commands.Teacher.Input;
using SoccerManager.Domain.Commands.Teacher.Output;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Repositories;
using SoccerManager.Domain.ValueObjects;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Handlers
{
    public class TeacherHandler : Notifiable, ICommandHandler<CreateTeacherCommand>
    {
        private ITeacherRepository _repository;

        public TeacherHandler(ITeacherRepository repository)
        {
            _repository = repository;

        }

        public ICommandResult Handle(CreateTeacherCommand command)
        {
            command.Validate();

            if(command.Invalid)
            {
                AddNotifications(command);
                return new TeacherCommandResult(false, "Nãoa foi possivel cadastrar o professor", Notifications);
            }

            var teacherBankAcconunt = new BankAccount(
                command.BankAccountName, 
                command.BankAccountAgency, 
                command.BankAccountNumber);

            var teacherName = new Name(
                command.FirstName, 
                command.LastName, 
                command.RG, 
                command.CPF);

            var teacher = new Teacher(
                command.Password,
                teacherBankAcconunt, 
                command.Earnings, 
                teacherName,
                command.Email,
                command.BithDate, 
                command.Gender, 
                command.Notes, 
                null);

            AddNotifications(teacherBankAcconunt, teacherName, teacher);

            if(Invalid)
                return new TeacherCommandResult(false, "Não foi possivel cadastrar o professor", Notifications);

            _repository.CreateTeacher(teacher);

            return new TeacherCommandResult(true, "Professor cadastrado com sucesso", 
                new { Id = teacher.Id, Name = teacher.Name.ToString() });


        }
    }
}
