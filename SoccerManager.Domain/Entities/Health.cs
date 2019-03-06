using SoccerManager.Shared.Entities;

namespace SoccerManager.Domain.Entities
{
    public class Health : Entity
    {
        protected Health() { }

        public Health(decimal height, decimal weight, string bloodPressure, string allergies, string disabilities, string notes)
        {
            Height = height;
            Weight = weight;
            BloodPressure = bloodPressure;
            Allergies = allergies;
            Disabilities = disabilities;
            Notes = notes;
        }

        public decimal Height { get; private set; }
        public decimal Weight { get; private set; }
        public string BloodPressure { get; private set; }
        public string Allergies { get; private set; }
        public string Disabilities { get; private set; }
        public string Notes { get; private set; }
    }
}
