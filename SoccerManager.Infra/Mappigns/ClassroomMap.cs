using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;
using System;

namespace SoccerManager.Infra.Mappigns
{
    public class ClassroomMap : IEntityTypeConfiguration<Classroom>
    {
        //public ClassroomMap()
        //{
        //    ToTable("Classroom");
        //    HasKey(x => x.Id);
        //    Property(x => x.Start);
        //    Property(x => x.End);
        //    Property(x => x.DayOfWeek);
        //}

        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.ToTable("Classroom");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Start).IsRequired();
            builder.Property(x => x.End).IsRequired();
            builder.Property(x => x.DayOfWeek).IsRequired();

            builder.Ignore(x => x.Notifications);
        }
    }
}
