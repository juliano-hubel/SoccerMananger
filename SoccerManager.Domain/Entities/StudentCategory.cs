using SoccerManager.Shared.Entities;

namespace SoccerManager.Domain.Entities
{
    public class StudentCategory : Entity
    {
        protected StudentCategory() { }
        public StudentCategory(string description, int maxAge)
        {
            Description = description;
            MaxAge = maxAge;
        }

        public string Description { get;  private set; }
        public int MaxAge { get; private set; }
    }
}
