using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class ExpeditionSectorConfiguration : IEntityTypeConfiguration<ExpeditionSector>
    {
        public void Configure(EntityTypeBuilder<ExpeditionSector> builder)
        {
            builder.HasKey(x => new { x.ExpeditionId, x.SectorId });

            builder.HasOne(x => x.Expedition)
                   .WithMany(x => x.Sectors)
                   .HasForeignKey(x => x.ExpeditionId);

            builder.HasOne(x => x.Sector)
                   .WithMany(x => x.Expeditions)
                   .HasForeignKey(x => x.SectorId);
        }
    }
}