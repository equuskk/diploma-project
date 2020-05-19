using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DiplomaProject.DataAccess.ContextFactories
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() +
                           string.Format("{0}..{0}DiplomaProject.WebApp", Path.DirectorySeparatorChar);

            var configuration = new ConfigurationBuilder()
                                .SetBasePath(basePath)
                                .AddJsonFile("appsettings.Development.json")
                                .AddEnvironmentVariables()
                                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseNpgsql(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}