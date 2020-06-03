using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class ThicketConfiguration : IEntityTypeConfiguration<Thicket>
    {
        public void Configure(EntityTypeBuilder<Thicket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Location)
                   .IsRequired()
                   .HasColumnType("geography");
            builder.Property(x => x.Date)
                   .IsRequired();
            builder.Property(x => x.WeightPerMeter)
                   .IsRequired();
            builder.Property(x => x.Length)
                   .IsRequired();
            builder.Property(x => x.Width)
                   .IsRequired();
            builder.Property(x => x.Stock)
                   .IsRequired();

            builder.HasOne(x => x.Litoral)
                   .WithMany()
                   .HasForeignKey(x => x.LitoralId);
            builder.HasOne(x => x.GroundType)
                   .WithMany()
                   .HasForeignKey(x => x.GroundTypeId);
            builder.HasOne(x => x.Seaweed)
                   .WithMany()
                   .HasForeignKey(x => x.SeaweedId);
        }
    }
}