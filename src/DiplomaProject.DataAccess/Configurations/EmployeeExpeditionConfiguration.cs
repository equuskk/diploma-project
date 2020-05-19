using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.DataAccess.Configurations
{
    public class EmployeeExpeditionConfiguration : IEntityTypeConfiguration<EmployeeExpedition>
    {
        public void Configure(EntityTypeBuilder<EmployeeExpedition> builder)
        {
            builder.HasKey(x => new { x.EmployeeId, x.ExpeditionId });

            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.Expeditions)
                   .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x => x.Expedition)
                   .WithMany(x => x.Employees)
                   .HasForeignKey(x => x.ExpeditionId);
        }
    }
}