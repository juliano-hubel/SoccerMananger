using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class GoalMap : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.ToTable("Goal");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PlayerNumber);
            builder.Property(x => x.Time);

            builder.Ignore(x => x.Notifications);
        }
    }
}
