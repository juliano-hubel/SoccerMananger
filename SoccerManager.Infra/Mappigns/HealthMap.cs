using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class HealthMap : IEntityTypeConfiguration<Health>
    {

        public void Configure(EntityTypeBuilder<Health> builder)
        {
            builder.ToTable("Health");
            builder.Property(x => x.Allergies);
            builder.Property(x => x.BloodPressure);
            builder.Property(x => x.Disabilities);
            builder.Property(x => x.Height);
            builder.Property(x => x.Notes);
            builder.Property(x => x.Weight);

            builder.Ignore(x => x.Notifications);
        }
    }
}
