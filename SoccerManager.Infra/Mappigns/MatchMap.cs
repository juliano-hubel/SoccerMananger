using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class MatchMap : IEntityTypeConfiguration<Match>
    {
        //public MatchMap()
        //{
        //    ToTable("Match");
        //    HasKey(x => x.Id);
        //    Property(x => x.Adversary);
        //    Property(x => x.Date);
        //    Property(x => x.Description);
        //    Property(x => x.FotoSumula);
        //    Property(x => x.Place);                        

        //    HasRequired(x => x.Team);
        //    HasMany(x => x.TeamFaults);
        //    HasMany(x => x.TeamCards);
        //    HasMany(x => x.TeamGoals);

        //    HasMany(x => x.AdversaryFaults);
        //    HasMany(x => x.AdversaryCards);
        //    HasMany(x => x.AdversaryGoals);
        //}

        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Match");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Adversary).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.FotoSumula);
            builder.Property(x => x.Place).IsRequired();

            builder.HasOne(x => x.Team);
            builder.HasMany(x => x.TeamFaults);
            builder.HasMany(x => x.TeamCards);
            builder.HasMany(x => x.TeamGoals);

            builder.HasMany(x => x.AdversaryFaults);
            builder.HasMany(x => x.AdversaryCards);
            builder.HasMany(x => x.AdversaryGoals);

            builder.Ignore(x => x.Notifications);            

        }
    }
}
