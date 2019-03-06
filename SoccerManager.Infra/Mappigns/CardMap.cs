using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerManager.Infra.Mappigns
{
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Card");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CardType).IsRequired();
            builder.Property(x => x.PlayerNumber).IsRequired(); 
            builder.Property(x => x.Time).IsRequired(); 

            builder.Ignore(x => x.Notifications);


               
        }
    }
}
