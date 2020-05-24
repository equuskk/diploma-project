using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class GroundTypeConfiguration : IEntityTypeConfiguration<GroundType>
    {
        public void Configure(EntityTypeBuilder<GroundType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}