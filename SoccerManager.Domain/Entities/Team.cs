using Flunt.Validations;
using SoccerManager.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public class Team : Entity
    {
        protected Team() { }

        private IList<Player> _players;

        public Team( string name, StudentCategory studentCategory, string notes)
        {
            Name = name;
            StudentCategory = studentCategory;
            Notes = notes;
            _players = new List<Player>();
        }

        public string Name { get; private set; }
        public StudentCategory StudentCategory { get; private set; }
        public string Notes { get; private set;}
        public ICollection<Player> Players => _players.ToArray();

        public void AddNotes(string notes)
        {
            Notes = notes;
        }

        public void AddPlayer(Player player)
        {            
            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(player.Student.Age, player.Team.StudentCategory.MaxAge,
                "Student.BirthDate", "A idade do aluno deve ser menor ou igual à idade maxima do time"));

            if (this.Valid)
                _players.Add(player);
        }
    }
}
