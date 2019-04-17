using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {


        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.DateEntered);
            builder.Property(x => x.Email);
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Notes);


            builder.OwnsOne(x => x.Payment)
                .Property(x => x.Fee);
            builder.OwnsOne(x => x.Payment)
                .Property(x => x.ExpirationDay);

            builder.OwnsOne(x => x.Payment)
                .Ignore(x => x.Notifications);

            builder.OwnsOne(x => x.Name).Property(x => x.FirstName).IsRequired();
            builder.OwnsOne(x => x.Name).Property(x => x.LastName).IsRequired();
            builder.OwnsOne(x => x.Name).Property(x => x.RG);
            builder.OwnsOne(x => x.Name).Property(x => x.CPF);
            builder.OwnsOne(x => x.Name).Ignore(x => x.Notifications);


            builder.OwnsOne(x => x.Father).Property(x => x.FirstName).IsRequired();
            builder.OwnsOne(x => x.Father).Property(x => x.LastName).IsRequired();
            builder.OwnsOne(x => x.Father).Property(x => x.RG).IsRequired();
            builder.OwnsOne(x => x.Father).Property(x => x.CPF).IsRequired();
            builder.OwnsOne(x => x.Father).Ignore(x => x.Notifications);

            
            builder.OwnsOne(x => x.Mother).Property(x => x.FirstName).IsRequired();
            builder.OwnsOne(x => x.Mother).Property(x => x.LastName).IsRequired();
            builder.OwnsOne(x => x.Mother).Property(x => x.RG).IsRequired();
            builder.OwnsOne(x => x.Mother).Property(x => x.CPF).IsRequired();
            builder.OwnsOne(x => x.Mother).Ignore(x => x.Notifications);

            builder.HasOne(x => x.Health);
            builder.HasOne(x => x.Address);

            builder.HasMany(x => x.StudentsClassrooms);

            builder.Ignore(x => x.Notifications);

        }
    }
}
