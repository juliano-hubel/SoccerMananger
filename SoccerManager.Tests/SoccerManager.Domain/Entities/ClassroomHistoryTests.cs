using NUnit.Framework;
using SoccerManager.Domain.Entities;
using SoccerManager.Domain.Enums;
using SoccerManager.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Tests.SoccerManager.Domain.Entities
{
    [TestFixture]
    public class ClassroomHistoryTests
    {

        private ClassroomHistory _classHistory;
        private Student _student;
        private Student _student1;
        private Student _student2;
        private Student _student3;
        private Student _student4;

        [SetUp]
        public void SetUp()
        {
            var classroom = new Classroom(DateTime.Now, DateTime.Now.AddHours(2), DayOfWeek.Monday);
            var teacherBankAcconunt = new BankAccount("abc", "111", "11111-1");
            var teacherName = new Name("José", "da Silva", "123456789", "78983757183");
            var teacher = new Teacher(string.Empty, teacherBankAcconunt, 100m, teacherName,
                "email@hotmail.com", DateTime.Now.AddDays(-25), EGender.Male, string.Empty, null);            

            _classHistory = new ClassroomHistory(classroom, teacher);


            var name = new Name("a", "b", "99999999", "99999999999");
            var payment = new Payment(1, 5);
            _student = new Student(name, name, payment,
                name, string.Empty, DateTime.MinValue,
                EGender.Male, string.Empty);

            name = new Name("c", "d", "888888888", "88888888888");
            payment = new Payment(1, 5);
            _student1 = new Student(name, name, payment,
                name, string.Empty, DateTime.MinValue,
                EGender.Male, string.Empty);

            name = new Name("c", "d", "77777777", "7777777777");
            payment = new Payment(1, 5);            
            _student2 = new Student(name, name, payment,
                name, string.Empty, DateTime.MinValue,
                EGender.Male, string.Empty);
        }

        [Test]
        public void Contructor_WhenCalled_ReturnValid()
        {            
            Assert.That(_classHistory.Valid);
        }

        [Test]
        public void AddTemporaryStudent_WhenCalled_ReturnValid()
        {
            _classHistory.AddTemporaryStudent(_student);
            Assert.That(_classHistory.Valid);
        }

        [Test]
        public void AddTemporaryStudent_WhenStundentAlreadyRegistered_ReturnInvalid()
        {

            //_classHistory.Classroom.Students.Add(_student);
            _classHistory.AddTemporaryStudent(_student);
            //Assert.That(_classHistory.Invalid);
            //Não se deve adicionar students ao classroom dessa forma
            Assert.Fail();
        }

        [Test]
        public void AddNotes_WhenValid_AddNote()
        {
            _classHistory.AddNotes("a", null);

            Assert.That(_classHistory.Notes == "a");
        }
     }
 }
