using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class SeaweedTypeConfiguration : IEntityTypeConfiguration<SeaweedType>
    {
        public void Configure(EntityTypeBuilder<SeaweedType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}