using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    class PlayerMap : IEntityTypeConfiguration<Player>
    {

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Number).IsRequired();
            builder.HasOne(x => x.Team);
            builder.HasOne(x => x.Student);

            builder.Ignore(x => x.Notifications);
        }
    }
}
