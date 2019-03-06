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
    public class MatchTests
    {
        private StudentCategory _studentCategory;
        private Team _team;
        private Match _match;
        private Goal _goal;
        private Card _card;
        private Fault _fault;



        [SetUp]
        public void SetUp()
        {
            int studentCategoryMaxAge = 20;
            _studentCategory = new StudentCategory("a", studentCategoryMaxAge);
            _team = new Team("a", _studentCategory, "b");
            _match = new Match(_team, "c", DateTime.Now.AddDays(1), "d");

            int matchTime = 5;
            int playerNumber = 10;
            _goal = new Goal(matchTime, playerNumber);
            _card = new Card(matchTime, playerNumber, ECardType.Yellow);
            _fault = new Fault(matchTime, playerNumber);


        }
        
        [Test]
        public void OnConstructor_ReturnValid()
        {           
           var match = new Match(_team, "c", DateTime.Now.AddDays(1), "d");
           Assert.That(match.Valid);
        }

        [Test]
        public void AddDescription_WhenCalled_AddADescription()
        {
            _match.AddDescription("a");
            Assert.AreEqual(_match.Description, "a");
        }

        [Test]
        public void AddTeamGoals_WhenCalled_AddGoals()
        {
            _match.AddTeamGoal(_goal);
            Assert.Greater(_match.TeamGoals.Count, 0);
            Assert.That(_match.Valid);
        }

        [Test]
        public void AddTeamCards_WhenCalled_AddCards()
        {
            _match.AddTeamCard(_card);
            Assert.Greater(_match.TeamCards.Count, 0);
            Assert.That(_match.Valid);
        }


        [Test]
        public void AddTeamFaults_WhenCalled_AddFaults()
        {
            _match.AddTeamFault(_fault);
            Assert.Greater(_match.TeamFaults.Count, 0);
            Assert.That(_match.Valid);
        }

        [Test]
        public void AddAdversaryGoals_WhenCalled_AddGoals()
        {
            _match.AddAdversaryGoal(_goal);
            Assert.Greater(_match.AdversaryGoals.Count, 0);
            Assert.That(_match.Valid);
        }

        [Test]
        public void AddAdversaryCards_WhenCalled_AddCards()
        {
            _match.AddAdversaryCard(_card);
            Assert.Greater(_match.AdversaryCards.Count, 0);
            Assert.That(_match.Valid);
        }
    
        [Test]
        public void AddAdversaryFaults_WhenCalled_AddFaults()
        {
            _match.AddAdversaryFault(_fault);
            Assert.Greater(_match.AdversaryFaults.Count, 0);
            Assert.That(_match.Valid);
        }

        [Test]
        public void AddFotoSumula_WhenCadlled_FillFotoSumula()
        {
            _match.AddFotoSumula("a");

            Assert.AreEqual(_match.FotoSumula, "a");
            Assert.That(_match.Valid);
        }






    }
}
