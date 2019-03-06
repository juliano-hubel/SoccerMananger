using Moq;
using NUnit.Framework;
using SoccerManager.Domain.Commands.Classroom.Input;
using SoccerManager.Domain.Handlers;
using SoccerManager.Domain.Repositories;
using System;

namespace SoccerManager.Tests.Handlers
{
    [TestFixture]
    public class ClassroomHandlerTests
    {
        private ClassroomHandler _handler;
        private CreateClassroomCommand _createClassroomCommand;
        private Mock<IClassroomRepository> _repository;
        private DateTime _baseDate => new DateTime(1900 , 01 , 01);
        [SetUp]
        public void SetUp()
        {

            _repository = new Mock<IClassroomRepository>();
            _handler = new ClassroomHandler(_repository.Object);
            _createClassroomCommand = new CreateClassroomCommand()
            {
                DayOfWeek = DayOfWeek.Friday,
                Start = _baseDate.AddHours(13),
                End = _baseDate.AddHours(15),
            };
        }

        [Test]
        public void CreateClassroomCommand_WhenCalled_AddClassroom()
        {            
            var result = _handler.Handle(_createClassroomCommand);
            Assert.That(result.Success);
        }

    }
}
