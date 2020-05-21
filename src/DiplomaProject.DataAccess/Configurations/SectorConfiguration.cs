using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Square)
                   .IsRequired();

            builder.HasMany(x => x.Bioresources)
                   .WithOne(x => x.Sector);
            builder.HasOne(x => x.Litoral)
                   .WithMany(x => x.Sectors);
        }
    }
}