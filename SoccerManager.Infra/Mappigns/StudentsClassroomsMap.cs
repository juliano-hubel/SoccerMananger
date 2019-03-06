using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerManager.Infra.Mappigns
{
    public class StudentsClassroomsMap : IEntityTypeConfiguration<StudentsClassrooms>
    {
        public void Configure(EntityTypeBuilder<StudentsClassrooms> builder)
        {
            builder.ToTable("StudentClassrooms");
            builder.HasKey(x => x.Id);
            builder.HasKey(x => new { x.StudentId, x.ClassroomId });
            builder.HasOne(x => x.Student)
                .WithMany(x => x.StudentsClassrooms)
                .HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Classroom)
                .WithMany(x => x.StudentsClassrooms)
                .HasForeignKey(x => x.ClassroomId);

            builder.Ignore(x => x.Notifications);


        }
    }
}
