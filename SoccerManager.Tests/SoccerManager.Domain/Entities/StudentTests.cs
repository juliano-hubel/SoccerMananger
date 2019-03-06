using NUnit.Framework;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Enums;
using SoccerManager.Domain.ValueObjects;
using System;

namespace SoccerManager.Tests.SoccerManager.Domain.Entities
{
    [TestFixture]
    public class StudentTests
    {
        private Student _student;
        private DateTime _defaultDate => new DateTime(1900, 1, 1);
        [SetUp]
        public void SetUp()
        {
            var name = new Name("a", "b", "99999999", "99999999999");
            var payment = new Payment(1, 5);
            

            _student = new Student(name, name, payment, 
                name, string.Empty, DateTime.MinValue,
                EGender.Male, string.Empty );            
        }
        [Test]
        public void AddClassRoom_WhenAddNewClassAfterExisting_ReturnValid()
        {
            var existingRoom = new Classroom(
                _defaultDate.AddHours(1),
                _defaultDate.AddHours(3).AddMinutes(30),
                DayOfWeek.Monday);


            var newRoom = new Classroom(
            _defaultDate.AddHours(3).AddMinutes(31),
            _defaultDate.AddHours(5),
            DayOfWeek.Monday);
            _student.AddClassroom(newRoom);

            Assert.That(_student.Valid, Is.True);
        }


        [Test]
        public void AddClassRoom_WhenAdd_ReturnValid()
        {       
             var newRoom = new Classroom(
             _defaultDate,
             _defaultDate.AddHours(2),
             DayOfWeek.Monday);
            _student.AddClassroom(newRoom);

            Assert.That(_student.Valid, Is.True);
        }

        [Test]
        public void AddClassRoom_WhenExistingClassroom_ReturnInvalid()
        {
            var existingRoom = new Classroom(
                _defaultDate.AddHours(1),
                _defaultDate.AddHours(3),
                DayOfWeek.Monday);


            var newRoom = new Classroom(
             _defaultDate,
             _defaultDate.AddHours(2),
             DayOfWeek.Monday);
            
            _student.AddClassroom(existingRoom);
            
            _student.AddClassroom(newRoom);

            Assert.That(_student.Invalid, Is.True);

        }

        [Test]
        public void AddClassRoom_WhenExistingClassroomAtSameTime_ReturnInvalid()
        {
            

            var existingRoom = new Classroom(
                _defaultDate.AddHours(1),
                _defaultDate.AddHours(3),
                DayOfWeek.Monday);


            var newRoom = new Classroom(
            _defaultDate.AddHours(1),
            _defaultDate.AddHours(3),
             DayOfWeek.Monday);

            _student.AddClassroom(existingRoom);
            _student.AddClassroom(newRoom);

            Assert.That(_student.Invalid, Is.True);

        }

        public void AddAddress_WhenIsValid_AddAddresToStudent()
        {
            var address = new Address("80030001", "Av. João Gualberto", 1259, "Juvevê", "Curitiba", "PR", "9885566622", "988552244");
            _student.AddAddress(address);
        }


    }
}
