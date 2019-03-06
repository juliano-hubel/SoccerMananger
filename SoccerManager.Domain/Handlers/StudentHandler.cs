using Flunt.Notifications;
using Flunt.Validations;
using SoccerManager.Domain.Commands.Student.Input;
using SoccerManager.Domain.Commands.Student.Output;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Repositories;
using SoccerManager.Domain.ValueObjects;
using SoccerManager.Shared.Commands;
using SoccerManager.Shared.Handlers;

namespace SoccerManager.Domain.Handlers
{
    public class StudentHandler : Notifiable,
        IHandler<CreateStudentCommand>,
        IHandler<AddAddressCommand>,
        IHandler<AddHealthCommand>,
        IHandler<AddClassroomCommand>,
        IHandler<RemoveClassRoomCommand>,
        IHandler<UpdateStudentCommand>
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IClassroomRepository _classroomRepository;

        public StudentHandler(
            IStudentRepository studentRepository,
            IClassroomRepository classroomRepository)
        {
            _studentRepository = studentRepository;
            _classroomRepository = classroomRepository;

        }

        public ICommandResult Handle(CreateStudentCommand command)
        {

            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível cadastrar o aluno", Notifications);
            }
            var motherName = new Name(
                command.MotherFirstName,
                command.MotherLastName,
                command.MotherRG,
                command.MotherCPF);

            var fatherName = new Name(
            command.FatherFirstName,
            command.FatherLastName,
            command.FatherRG,
            command.FatherCPF);

            var studentName = new Name(
            command.StudentFirstName,
            command.StudentLastName,
            command.StudentRG,
            command.StudentCPF);

            var payment = new Payment(
                command.PaymentFee,
                command.PaymentExpirationDay);

            var student = new Student(
                fatherName,
                motherName,
                payment,
                studentName,
                command.Email,
                command.BirthDate,
                command.Gender,
                command.Notes);

            AddNotifications(motherName, fatherName, studentName, payment, student);

            if (Invalid)
                return new CommandResult(false, "Não foi possível cadastrar o aluno", null);

            _studentRepository.CreateStudent(student);

            return new CommandResult(true, "Aluno registrado com sucesso", 
                new { Id = student.Id, Name = student.Name.ToString()});
        }

        public ICommandResult Handle(AddClassroomCommand command)
         {
            command.Validate();

            if(command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao vincular aula ao aluno", Notifications);
            }

            var classroom = _classroomRepository.GetById(command.ClassroomId);
            var student = _studentRepository.GetById(command.StudentId);


            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(student, "StudentId", "O ID do aluno é inválido ou não existe")
                .IsNotNull(classroom, "ClassroomId", "O ID da aula é inválido ou não existe"));

            var studentsClassrooms = new StudentsClassrooms(student, classroom);
            
            AddNotifications(student, classroom, studentsClassrooms);

            if (Invalid)
                return new CommandResult(false, "Erro ao vincular aula ao aluno", Notifications);

            _studentRepository.AddClassroom(studentsClassrooms);            

            return new CommandResult(true, "Aula vinculada ao aluno.", command);

        }

        public ICommandResult Handle(AddHealthCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao adicionar", Notifications);
            }
            var student = _studentRepository.GetById(command.StudentID);
            var health = new Health
                (
                    command.Height,
                    command.Weight,
                    command.BloodPressure,
                    command.Allergies,
                    command.Disabilities,
                    command.Notes
                );

            student.AddHealth(health);

            AddNotifications(student, health);
            
            if(Invalid)
                return new CommandResult(false, "Erro ao adicionar.", Notifications);

            _studentRepository.AddHealth(student.Id, health);

            return new CommandResult(true, "Dados cadastrados com sucesso", Notifications);
        }

        public ICommandResult Handle(RemoveClassRoomCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao remover", Notifications);
            }

            var classroom = _classroomRepository.GetById(command.ClassroomId);
            var student = _studentRepository.GetById(command.StudentId);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(student, "StudentId", "O ID do aluno é inválido ou não existe")
                .IsNotNull(classroom, "ClassroomId", "O ID da aula é inválido ou não existe"));

            AddNotifications(student, classroom);

            if (Invalid)
                return new CommandResult(false, "Erro ao remover aula", Notifications);

            _studentRepository.RemoveClassroom(student.Id, classroom.Id);

            return new CommandResult(true, "Aula removida.", command);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Erro ao adicionar", Notifications);
            }
            var student = _studentRepository.GetById(command.StudentID);
            var address = new Address
                (
                    command.ZipCode, 
                    command.Street,
                    command.Number,
                    command.Neighborhood,
                    command.City,
                    command.State,
                    command.PhoneNumber,
                    command.CellPhoneNumber
                );

            student.AddAddress(address);

            AddNotifications(student, address);

            if (Invalid)
                return new CommandResult(false, "Erro ao adicionar.", Notifications);

            _studentRepository.AddAddress(student.Id, address);

            return new CommandResult(true, "Dados cadastrados com sucesso", Notifications);
        }

        public ICommandResult Handle(UpdateStudentCommand command)
        {

            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível cadastrar o aluno", Notifications);
            }
            var motherName = new Name(
                command.MotherFirstName,
                command.MotherLastName,
                command.MotherRG,
                command.MotherCPF);

            var fatherName = new Name(
            command.FatherFirstName,
            command.FatherLastName,
            command.FatherRG,
            command.FatherCPF);

            var studentName = new Name(
            command.StudentFirstName,
            command.StudentLastName,
            command.StudentRG,
            command.StudentCPF);

            var payment = new Payment(
                command.PaymentFee,
                command.PaymentExpirationDay);


            var student = _studentRepository.GetById(command.Id);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(student, "student", "O aluno não existe"));

            if (Invalid)
                return new CommandResult(false, "Não foi possível alterar o aluno", Notifications);

            student.UpdateStudent(
                fatherName,
                motherName,
                payment,
                studentName,
                command.Email,
                command.BirthDate,
                command.Gender,
                command.Notes);


            AddNotifications(motherName, fatherName, studentName, payment, student);

            if (Invalid)
                return new CommandResult(false, "Não foi possível alterar o aluno", Notifications);

            _studentRepository.UpdateStudent(student);

            return new CommandResult(true, "Aluno alterado com sucesso",
                new { Id = student.Id, Name = student.Name.ToString() });

        }
    }
}
