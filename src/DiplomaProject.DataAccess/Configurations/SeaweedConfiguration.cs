using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class SeaweedConfiguration : IEntityTypeConfiguration<Seaweed>
    {
        public void Configure(EntityTypeBuilder<Seaweed> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(x => x.Type)
                   .WithMany()
                   .HasForeignKey(x => x.SeaweedTypeId);

            builder.HasOne(x => x.Category)
                   .WithMany()
                   .HasForeignKey(x => x.SeaweedCategoryId);
        }
    }
}