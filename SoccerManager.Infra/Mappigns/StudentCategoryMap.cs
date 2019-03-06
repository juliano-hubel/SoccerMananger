using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class StudentCategoryMap : IEntityTypeConfiguration<StudentCategory>
    {
        
        public void Configure(EntityTypeBuilder<StudentCategory> builder)
        {
            builder.ToTable("StudentCategory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.MaxAge).IsRequired();

            builder.Ignore(x => x.Notifications);
        }
    }
}
