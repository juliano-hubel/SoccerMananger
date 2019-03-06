using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class TeacherMap : IEntityTypeConfiguration<Teacher>
    {

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Earnings).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Notes);
            builder.Property(x => x.Password).IsRequired();

            builder.OwnsOne(x => x.Name).Property(x => x.FirstName).IsRequired();
            builder.OwnsOne(x => x.Name).Property(x => x.LastName).IsRequired();
            builder.OwnsOne(x => x.Name).Property(x => x.RG);
            builder.OwnsOne(x => x.Name).Property(x => x.CPF);
            builder.OwnsOne(x => x.Name).Ignore(x => x.Notifications);

            builder.HasOne(x => x.BankAccount);
            builder.HasOne(x => x.Address);

            builder.Ignore(x => x.Notifications);
        }
    }
}
