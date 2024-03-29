﻿using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Location)
                   .HasColumnType("geography");

            builder.Property(x => x.Title)
                   .IsRequired();

            builder.HasOne(x => x.Sector)
                   .WithMany()
                   .HasForeignKey(x => x.SectorId);
        }
    }
}