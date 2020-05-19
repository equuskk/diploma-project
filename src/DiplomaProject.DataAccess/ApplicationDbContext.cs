using DiplomaProject.DataAccess.Configurations;
using DiplomaProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<Employee, IdentityRole, string>
    {
        public DbSet<Bioresource> Bioresources { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<Litoral> Litorals { get; set; }
        public DbSet<Sector> Sectors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BioresourceConfiguration());
            builder.ApplyConfiguration(new EmployeeExpeditionConfiguration());
            builder.ApplyConfiguration(new EmployeePositionConfiguration());
            builder.ApplyConfiguration(new ExpeditionConfiguration());
            builder.ApplyConfiguration(new ExpeditionSectorConfiguration());
            builder.ApplyConfiguration(new LitoralConfiguration());
            builder.ApplyConfiguration(new SectorConfiguration());
        }
    }
}