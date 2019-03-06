using SoccerManager.Shared.Entities;

namespace SoccerManager.Domain.Entities
{
    public class Fault : Entity
    {
        public Fault(int time, int playerNumber)
        {
            Time = time;
            PlayerNumber = playerNumber;
        }

        public int Time { get; private set; }
        public int PlayerNumber { get; private set; }
    }
}
