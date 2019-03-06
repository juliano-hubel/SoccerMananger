using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerManager.Infra.Mappigns
{
    public class FaultMap : IEntityTypeConfiguration<Fault>
    {
        public void Configure(EntityTypeBuilder<Fault> builder)
        {
            builder.ToTable("Fault");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PlayerNumber);
            builder.Property(x => x.Time);

            builder.Ignore(x => x.Notifications);
        }
    }
}
