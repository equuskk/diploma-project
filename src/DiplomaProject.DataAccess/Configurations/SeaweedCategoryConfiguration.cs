using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class SeaweedCategoryConfiguration : IEntityTypeConfiguration<SeaweedCategory>
    {
        public void Configure(EntityTypeBuilder<SeaweedCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}