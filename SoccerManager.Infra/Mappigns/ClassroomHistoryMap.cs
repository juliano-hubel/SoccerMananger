using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    class ClassroomHistoryMap : IEntityTypeConfiguration<ClassroomHistory>
    {        

        public void Configure(EntityTypeBuilder<ClassroomHistory> builder)
        {
            builder.ToTable("ClassroomHistory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Notes);


            builder.HasMany(x => x.MarkedUpStudents);
            builder.HasOne(x => x.Classroom);
            builder.HasMany(x => x.PresentStudents);
            builder.HasOne(x => x.Teacher);
            builder.HasMany(x => x.TemporaryStudents);

            builder.Ignore(x => x.Notifications);
        }
    }
}
