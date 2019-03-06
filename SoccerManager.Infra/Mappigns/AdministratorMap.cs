using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;

namespace SoccerManager.Infra.Mappigns
{
    public class AdministratorMap : IEntityTypeConfiguration<Administrator>
    {
        //public AdministratorMap()
        //{
        //    ToTable("Admnistrator");
        //    HasKey(x => x.Id);
        //    Property(x => x.BirthDate);            
        //    Property(x => x.Earnings);
        //    Property(x => x.Email);
        //    Property(x => x.Gender);
        //    Property(x => x.Notes);
        //    Property(x => x.Password);

        //    Property(x => x.Name.FirstName);
        //    Property(x => x.Name.CPF);
        //    Property(x => x.Name.LastName);
        //    Property(x => x.Name.RG);

        //    HasOptional(x => x.BankAccount);
        //    HasOptional(x => x.Address);


        //}

        public void Configure(EntityTypeBuilder<Administrator> builder)
        {            
            
            builder.ToTable("Admnistrator");                        
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Earnings).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Notes);
            builder.Property(x => x.Password).IsRequired(); 

            builder.OwnsOne(x => x.Name).Property(x => x.FirstName).IsRequired();
            builder.OwnsOne(x => x.Name).Property(x => x.LastName).IsRequired();
            builder.OwnsOne(x => x.Name).Property(x => x.RG).IsRequired();
            builder.OwnsOne(x => x.Name).Property(x => x.CPF).IsRequired();

            //builder.OwnsOne(x => x.BankAccount).Ignore(x => x.Notifications);
            //builder.OwnsOne(x => x.Address).Ignore(x => x.Notifications); 
            builder.HasOne(x => x.BankAccount);
            builder.HasOne(x => x.Address);


            builder.OwnsOne(x => x.Name)
                .Ignore(y => y.Notifications);
            builder.Ignore(x => x.Notifications);

        }
    }
}
