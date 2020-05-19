using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class BioresourceConfiguration : IEntityTypeConfiguration<Bioresource>
    {
        public void Configure(EntityTypeBuilder<Bioresource> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Square)
                   .IsRequired();
            builder.Property(x => x.Weight)
                   .IsRequired();
            builder.Property(x => x.Type)
                   .IsRequired(); //TODO:

            builder.HasOne(x => x.Sector)
                   .WithMany(x => x.Bioresources);
        }
    }
}