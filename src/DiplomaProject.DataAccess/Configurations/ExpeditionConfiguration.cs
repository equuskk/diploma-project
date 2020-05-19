using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class ExpeditionConfiguration : IEntityTypeConfiguration<Expedition>
    {
        public void Configure(EntityTypeBuilder<Expedition> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FromDate)
                   .IsRequired();
            builder.Property(x => x.ToDate)
                   .IsRequired();
        }
    }
}