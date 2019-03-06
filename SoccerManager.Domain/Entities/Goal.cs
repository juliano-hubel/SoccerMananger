using SoccerManager.Shared.Entities;
using SoccerManager.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public class Goal : Entity
    {
        public Goal(int time,int playerNumber)
        {
            PlayerNumber = playerNumber;
            Time = time;
        }

        public int PlayerNumber { get; private set; }
        public int Time { get; private set; }
    }
}
