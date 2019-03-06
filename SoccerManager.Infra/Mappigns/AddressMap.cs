using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CellPhoneNumber);
            builder.Property(x => x.City);
            builder.Property(x => x.Neighborhood);
            builder.Property(x => x.Number);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.State);
            builder.Property(x => x.Street);
            builder.Property(x => x.ZipCode);

            builder.Ignore(x => x.Notifications);
        }
    }
}
