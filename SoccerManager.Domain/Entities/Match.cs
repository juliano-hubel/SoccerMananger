using SoccerManager.Domain.ValueObjects;
using SoccerManager.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public class Match : Entity
    {
        protected Match(){}

        private IList<Goal> _teamGoals;
        private IList<Card> _teamCards;
        private IList<Fault> _teamFaults;
        private IList<Goal> _adversaryGoals;
        private IList<Card> _adversaryCards;
        private IList<Fault> _adversaryFaults;

        public Match(Team team, string adversary, DateTime date, string place)
        {            
            Team = team;            
            Adversary = adversary;            
            Date = date;
            Place = place;
           _teamGoals =  new List<Goal>();
           _teamCards = new List<Card>();
           _teamFaults = new List<Fault>();
           _adversaryGoals =  new List<Goal>();
           _adversaryCards =  new List<Card>();
           _adversaryFaults = new List<Fault>();
        }

        public string Description { get; set; }
        public Team Team { get; set; }
        public ICollection<Goal> TeamGoals => _teamGoals.ToArray();
        public ICollection<Card> TeamCards => _teamCards.ToArray();
        public ICollection<Fault> TeamFaults => _teamFaults.ToArray();
        public string Adversary { get; set; }
        public ICollection<Goal> AdversaryGoals => _adversaryGoals.ToArray();
        public ICollection<Card> AdversaryCards => _adversaryCards.ToArray();
        public ICollection<Fault> AdversaryFaults => _adversaryFaults.ToArray();
        public string FotoSumula { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }

        public void AddDescription(string description)
        {
            Description = description;
        }    
        public void AddTeamGoal(Goal goal)
        {
            _teamGoals.Add(goal);
        }
        public void AddTeamCard(Card card)
        {
            _teamCards.Add(card);
        }
        public void AddTeamFault(Fault fault)
        {
            _teamFaults.Add(fault);
        }
        public void AddAdversaryGoal(Goal goal)
        {
            _adversaryGoals.Add(goal);
        }
        public void AddAdversaryCard(Card card)
        {
            _adversaryCards.Add(card);
        }
        public void AddAdversaryFault(Fault fault)
        {
            _adversaryFaults.Add(fault);
        }

        public void AddFotoSumula(string fotoSumula)
        {
            FotoSumula = fotoSumula;
        }

    }
}
