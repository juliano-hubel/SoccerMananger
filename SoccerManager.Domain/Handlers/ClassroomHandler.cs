using Flunt.Notifications;
using SoccerManager.Domain.Commands.Classroom.Input;
using SoccerManager.Domain.Commands.Classroom.Output;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Repositories;
using SoccerManager.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Handlers
{
    public class ClassroomHandler : Notifiable,
        ICommandHandler<CreateClassroomCommand>
    {
        private IClassroomRepository _repository;
        public ClassroomHandler(IClassroomRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateClassroomCommand command)
        {

            //Fail Fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new ClassroomCommandResult(false, "Erro ao vincular aula ao aluno", Notifications);
            }

            // Cria a entidade
            var classroom = new Classroom(command.Start, command.End, command.DayOfWeek);

            //adiciona validações
            AddNotifications(classroom);        
            if (Invalid)
                return new ClassroomCommandResult(false, "Erro ao criar a aula.", classroom.Notifications);

            //persiste no banco
            _repository.AddClassroom(classroom);


            //retorna com sucesso
            return new ClassroomCommandResult(true, "Aula criada com sucesso", new { Id = classroom.Id });
        }
    }
}
