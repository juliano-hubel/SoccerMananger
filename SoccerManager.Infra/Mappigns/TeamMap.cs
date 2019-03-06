using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Notes);
            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.StudentCategory);

            builder.HasMany(x => x.Players);

            builder.Ignore(x => x.Notifications);
        }
    }
}
