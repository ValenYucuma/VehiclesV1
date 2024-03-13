using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(p => p.ID);

            builder.Property(p => p.Brand)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.Km)
                .IsRequired();

            builder.Property(p => p.Model)
                .IsRequired();

            builder.Property(p => p.LocationId)
                .IsRequired();

            builder.Property(p => p.Type)
                .HasMaxLength(100);
        }
    }
}
