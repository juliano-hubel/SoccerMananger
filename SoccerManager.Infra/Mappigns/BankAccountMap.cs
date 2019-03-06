using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class BankAccountMap :  IEntityTypeConfiguration<BankAccount>
    {
        //public BankAccountMap()
        //{
        //    ToTable("BankAccount");
        //    HasKey(x => x.Id);
        //    Property(x => x.AccountNumber);
        //    Property(x => x.Agency);
        //    Property(x => x.BankName);            
        //}

        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccount");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AccountNumber).IsRequired();
            builder.Property(x => x.Agency).IsRequired();
            builder.Property(x => x.BankName).IsRequired();

            builder.Ignore(x => x.Notifications);
        }
    }
}
