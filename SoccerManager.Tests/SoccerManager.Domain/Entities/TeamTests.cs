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
    class TeamTests
    {
        private Team _team;
        private Student _student;
        private Name _name;
        private Payment _payment;
        private DateTime _birthDate;

        [SetUp]
        public void SetUp()
        {
            var studentCategory = new StudentCategory("Sub19", 19);
            _team = new Team("Time 1", studentCategory, "Time de Sub19");

            _name = new Name("a", "b", "99999999", "99999999999");
            _payment = new Payment(1, 5);

            _birthDate = DateTime.Now.AddYears(-19);

            _student = new Student(_name, _name, _payment,
                _name, string.Empty, _birthDate,
                EGender.Male, string.Empty);
        }

        [Test]
        public void AddPlayers_WhenCalled_AddPlayersToTeam()
        {
            var player = new Player(1, _team, _student);
            _team.AddPlayer(player);
            Assert.That(_team.Players.Count > 0);
        }

        [Test]
        [TestCase(20)]
        [TestCase(21)]        
        public void AddPlayers_WhenStudantAgeIsHighThenStudentCategory_ReturnInvalid(int years)
        {

            _birthDate = DateTime.Now.AddYears(-years);
            _student = new Student(_name, _name, _payment,
             _name, string.Empty, _birthDate,
             EGender.Male, string.Empty);

            var player = new Player(1, _team, _student);
            _team.AddPlayer(player);
            Assert.That(_team.Invalid, Is.True);
        }

        [Test]
        public void AddNotes_WhenCalled_ModifytheNotes()
        {
            _team.AddNotes("a");

            Assert.AreEqual(_team.Notes, "a");
        }

    }
}
