using SoccerManager.Domain.Enums;
using SoccerManager.Shared.Entities;
using SoccerManager.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Domain.Entities
{
    public class Card : Entity
    {
        public Card(int time, int playerNumber, ECardType cardType)
        {
            Time = time;
            PlayerNumber = playerNumber;
            CardType = cardType;
        }

        public int Time { get; private set; }
        public int PlayerNumber { get; private set; }
        public ECardType CardType { get; private set; }
    }
}
