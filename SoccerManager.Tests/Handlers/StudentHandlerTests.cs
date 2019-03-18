using Moq;
using NUnit.Framework;
using SoccerManager.Domain.Commands.Student.Input;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Enums;
using SoccerManager.Domain.Handlers;
using SoccerManager.Domain.Repositories;
using SoccerManager.Domain.ValueObjects;
using System;

namespace SoccerManager.Tests.Handlers
{
    [TestFixture]
    public class StudentHandlerTests
    {
        private CreateStudentCommand _createStudentCommand;
        private UpdateStudentCommand _updateStudentCommand;
        private AddClassroomCommand _addClassroomCommand;
        private AddAddressCommand _addAddressCommand;
        private Student _student;
        private Address _address;
        private Classroom _classroom;
        private Mock<IStudentRepository> _studentRepository;
        private Mock<IClassroomRepository> _classroomRepository;
        private Mock<IAddressRepository> _addressRepository;
        private RemoveStudentCommand _removeStudentCommand;
        private UpdateAddressCommand _updateAddressCommand;

        [SetUp]
        public void SetUp()
        {
            BuildStudentEntity();
            BuildAdressEntity();
            BuildClassroomEntity();
            BuildCreateStudentCommand();
            BuildAddClassroomCommand();
            BuildAddAddressCommand();
            BuildUpdateStudentCommand();
            BuildRemoveStudentCommand();
            BuildUpdateAdressCommand();
            

            _studentRepository = new Mock<IStudentRepository>();
            _classroomRepository = new Mock<IClassroomRepository>();
            _addressRepository = new Mock<IAddressRepository>();

        }
        private void BuildAdressEntity()
        {
            _address = new Address(
                "80030001",
                "Av. João Gualberto",
                1259,
                "Juvevê",
                "Curitiba",
                "PR",
                "31569151",
                "98833471");
            _student.AddAddress(_address);
        }


        private void BuildRemoveStudentCommand()
        {
            _removeStudentCommand = new RemoveStudentCommand(Guid.NewGuid());

        }

        private void BuildUpdateAdressCommand()
        {
            _updateAddressCommand = new UpdateAddressCommand();
            _updateAddressCommand.StudentID = _student.Id;
            _updateAddressCommand.AddressID = _student.Address.Id;
            _updateAddressCommand.ZipCode = "80030001";
            _updateAddressCommand.Street = "Av. João Gualberto 1259";
            _updateAddressCommand.Number = 1259;
            _updateAddressCommand.Neighborhood = "Juvevê";
            _updateAddressCommand.City = "Curitiba";
            _updateAddressCommand.State = "PR";
            _updateAddressCommand.PhoneNumber = "31569151";
            _updateAddressCommand.CellPhoneNumber = "988334701";
            
        }

        private void BuildCreateStudentCommand()
        {
            _createStudentCommand = new CreateStudentCommand();
            _createStudentCommand.StudentFirstName = "Juliano";
            _createStudentCommand.StudentLastName = "Hubel";
            _createStudentCommand.StudentRG = "91069652";
            _createStudentCommand.StudentCPF = "07910968906";
            _createStudentCommand.Email = "juliano_hubel@hotmail.com";
            _createStudentCommand.BirthDate = new DateTime(1993, 10, 14);
            _createStudentCommand.Gender = EGender.Male;
            _createStudentCommand.Notes = "";
            _createStudentCommand.FatherFirstName = "Nivaldo";
            _createStudentCommand.FatherLastName = "Hubel";
            _createStudentCommand.FatherRG = "123456789";
            _createStudentCommand.FatherCPF = "40729745015";
            _createStudentCommand.MotherFirstName = "Maria";
            _createStudentCommand.MotherLastName = "Hubel";
            _createStudentCommand.MotherRG = "897464584";
            _createStudentCommand.MotherCPF = "99097014050";
            _createStudentCommand.PaymentFee = 59;
            _createStudentCommand.PaymentExpirationDay = 5;
        }

        private void BuildAddClassroomCommand()
        {
            _addClassroomCommand = new AddClassroomCommand();
            _addClassroomCommand.StudentId = Guid.NewGuid();
            _addClassroomCommand.ClassroomId = Guid.NewGuid();
        }

        private void BuildAddAddressCommand()
        {
            _addAddressCommand = new AddAddressCommand()
            {
                StudentID = Guid.NewGuid(),
                ZipCode = "80030001",                
                Street =  "Av. João Gualberto",
                Number = 1259,
                Neighborhood = "Juvevê",
                City = "Curitiba",
                State = "PR",
                PhoneNumber = "9885566622",
                CellPhoneNumber = "988552244"
            };

        }

        private void BuildStudentEntity()
        {
            string firstName = "Juliano";
            string lastName = "Hubel";
            string rg = "99999999";
            string cpf = "99999999999";
            decimal studentFee = 1;
            int expirationDay = 2;

            var name = new Name(firstName, lastName, rg, cpf);
            var payment = new Payment(studentFee, expirationDay);
            _student = new Student(name, name, payment,
                name, string.Empty, DateTime.MinValue,
                EGender.Male, string.Empty);
        }

        private void BuildClassroomEntity()
        {
            _classroom = new Classroom
                (
                    DateTime.Now.AddHours(1),
                    DateTime.Now.AddHours(3),
                    DayOfWeek.Monday
                );
        }

        private void BuildUpdateStudentCommand()
        {
            _updateStudentCommand = new UpdateStudentCommand();
            _updateStudentCommand.Id = Guid.NewGuid();
            _updateStudentCommand.StudentFirstName = "Juliano";
            _updateStudentCommand.StudentLastName = "Hubel";
            _updateStudentCommand.StudentRG = "91069652";
            _updateStudentCommand.StudentCPF = "07910968906";
            _updateStudentCommand.Email = "juliano_hubel@hotmail.com";
            _updateStudentCommand.BirthDate = new DateTime(1993, 10, 14);
            _updateStudentCommand.Gender = EGender.Male;
            _updateStudentCommand.Notes = "";
            _updateStudentCommand.FatherFirstName = "Nivaldo";
            _updateStudentCommand.FatherLastName = "Hubel";
            _updateStudentCommand.FatherRG = "123456789";
            _updateStudentCommand.FatherCPF = "40729745015";
            _updateStudentCommand.MotherFirstName = "Maria";
            _updateStudentCommand.MotherLastName = "Hubel";
            _updateStudentCommand.MotherRG = "897464584";
            _updateStudentCommand.MotherCPF = "99097014050";
            _updateStudentCommand.PaymentFee = 59;
            _updateStudentCommand.PaymentExpirationDay = 5;
        }

        [Test]
        public void Handle_CreateStudentCommand_WhenCalled_CreateStudent()
        {
            var studentHandler = new StudentHandler(
                _studentRepository.Object,
                _classroomRepository.Object,
                _addressRepository.Object);
            studentHandler.Handle(_createStudentCommand);

            Assert.That(_createStudentCommand.Valid, Is.True);
        }

        [Test]
        public void Handle_AddClassroomCommand_WhenCalled_AddClassroom()
        {
            _studentRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(_student);
            _classroomRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(_classroom);

            var studentHandler = new StudentHandler(
                _studentRepository.Object,
                _classroomRepository.Object,
                _addressRepository.Object);

            studentHandler.Handle(_addClassroomCommand);

            Assert.That(_addClassroomCommand.Valid, Is.True);
        }

        [Test]
        public void Handle_AddClassroomCommand_WhenStudentNotExists_ThrowsException()
        {
            _studentRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Throws<Exception>();
            _classroomRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(_classroom);

            var studentHandler = new StudentHandler(
                _studentRepository.Object,
                _classroomRepository.Object,
                _addressRepository.Object);
            Assert.That(() => studentHandler.Handle(_addClassroomCommand), Throws.Exception);
        }
        
        [Test]
        public void Handle_AddAddressCommand_WhenCalled_AddAddressToStudent()
        {
            _studentRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(_student);
            _classroomRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(_classroom);

            var studentHandler = new StudentHandler(
                _studentRepository.Object,
                _classroomRepository.Object,
                _addressRepository.Object);

            studentHandler.Handle(_addAddressCommand);
            Assert.That(_addAddressCommand.Valid, Is.True);

        }

        [Test]
        public void Handle_UpdateStudentCommand_WhenCalled_UpdateStudent()
        {
            _studentRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(_student);

            var studentHandler = new StudentHandler(
                 _studentRepository.Object,
                 _classroomRepository.Object,
                 _addressRepository.Object);
            var result = studentHandler.Handle(_updateStudentCommand);
            Assert.That(result.Success);

        }

        [Test]
        public void Handle_UpdateStudentCommand_WhenStudentIsNull_ReturnInvalid()
        {
            _studentRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(It.IsAny<Student>);

            var studentHandler = new StudentHandler(
                 _studentRepository.Object,
                 _classroomRepository.Object,
                 _addressRepository.Object);
            var result = studentHandler.Handle(_updateStudentCommand);
            Assert.That(!result.Success);

        }

        [Test]
        public void Handle_RemoveStudentCommand_RemoveStudent()
        {
            _studentRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(_student);
            _studentRepository.Setup(r => r.Remove(_student));

            var studentHandler = new StudentHandler(
                _studentRepository.Object,
                _classroomRepository.Object,
                _addressRepository.Object);

            var result = studentHandler.Handle(_removeStudentCommand);
            Assert.That(result.Success);
        }
        [Test]
        public void Handle_UpdateAddressCommand_UpdateAddress()
        {
            _studentRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(_student);
            _addressRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(_student.Address);
            _addressRepository.Setup(r => r.Update(_student.Address));

            var studentHandler = new StudentHandler(
                 _studentRepository.Object,
                 _classroomRepository.Object,
                 _addressRepository.Object);

            var result = studentHandler.Handle(_updateAddressCommand);
            Assert.That(result.Success);

        }




    }
}
