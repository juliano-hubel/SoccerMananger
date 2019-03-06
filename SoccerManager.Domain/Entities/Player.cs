using SoccerManager.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public class Player : Entity
    {
        protected Player(){ }        

        public Player(int number, Team team, Student student)
        {
            Number = number;
            Team = team;
            Student = student;
        }

        public int Number { get; private set; }        
        public Team Team { get; private set; }
        public Student Student { get; private set; }
    }
}
