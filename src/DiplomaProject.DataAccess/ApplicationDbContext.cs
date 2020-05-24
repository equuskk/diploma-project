using DiplomaProject.DataAccess.Configurations;
using DiplomaProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<Employee, IdentityRole, string>
    {
        public DbSet<EmployeeExpedition> EmployeeExpeditions { get; set; }
        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<ExpeditionSector> ExpeditionSectors { get; set; }
        public DbSet<GroundType> GroundTypes { get; set; }
        public DbSet<Litoral> Litorals { get; set; }
        public DbSet<SeaweedCategory> SeaweedCategories { get; set; }
        public DbSet<Seaweed> Seaweeds { get; set; }
        public DbSet<SeaweedType> SeaweedTypes { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<StationData> StationsData { get; set; }
        public DbSet<Thicket> Thickets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("postgis");
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EmployeeExpeditionConfiguration());
            builder.ApplyConfiguration(new ExpeditionConfiguration());
            builder.ApplyConfiguration(new ExpeditionSectorConfiguration());
            builder.ApplyConfiguration(new GroundTypeConfiguration());
            builder.ApplyConfiguration(new LitoralConfiguration());
            builder.ApplyConfiguration(new SeaweedCategoryConfiguration());
            builder.ApplyConfiguration(new SeaweedConfiguration());
            builder.ApplyConfiguration(new SeaweedTypeConfiguration());
            builder.ApplyConfiguration(new SectorConfiguration());
            builder.ApplyConfiguration(new StationConfiguration());
            builder.ApplyConfiguration(new StationDataConfiguration());
            builder.ApplyConfiguration(new ThicketConfiguration());
        }
    }
}