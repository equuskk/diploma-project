using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class StationDataConfiguration : IEntityTypeConfiguration<StationData>
    {
        public void Configure(EntityTypeBuilder<StationData> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
                   .IsRequired();

            builder.Property(x => x.Temperature)
                   .IsRequired();
            builder.Property(x => x.Density)
                   .IsRequired();
            builder.Property(x => x.Depth)
                   .IsRequired();

            builder.HasOne(x => x.Station)
                   .WithMany(x => x.StationData)
                   .HasForeignKey(x => x.StationId);
        }
    }
}