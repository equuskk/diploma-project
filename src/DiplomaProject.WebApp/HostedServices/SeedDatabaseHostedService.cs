using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiplomaProject.WebApp.HostedServices
{
    public class SeedDatabaseHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public SeedDatabaseHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Migrate<ApplicationDbContext>(cancellationToken);
            await Seed();
        }

        private async Task Seed()
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await SeedLitorals();
            await SeedGroundTypes();
            await SeedSeaweedTypes();
            await SeedSeaweedCategories();

            async Task SeedGroundTypes()
            {
                var isGroundTypesEmpty = !await dbContext.GroundTypes.AnyAsync();
                if(isGroundTypesEmpty)
                {
                    await dbContext.GroundTypes.AddRangeAsync(new GroundType("Мелкий песок"), new GroundType("Крупный песок"),
                                                              new GroundType("Песок"), new GroundType("Дерновина"),
                                                              new GroundType("Камни"), new GroundType("Ил"));
                    await dbContext.SaveChangesAsync();
                }
            }

            async Task SeedLitorals()
            {
                var isLitoralsEmpty = !await dbContext.Litorals.AnyAsync();
                if(isLitoralsEmpty)
                {
                    await dbContext.Litorals.AddRangeAsync(new Litoral("Скальная литораль"), new Litoral("Каменистая литораль"),
                                                           new Litoral("Песчаная литораль"), new Litoral("Илистая литораль"));
                    await dbContext.SaveChangesAsync();
                }
            }

            async Task SeedSeaweedTypes()
            {
                var isSeaweedTypesEmpty = !await dbContext.SeaweedTypes.AnyAsync();
                if(isSeaweedTypesEmpty)
                {
                    await dbContext.SeaweedTypes.AddRangeAsync(new SeaweedType("Ahnfelia"),
                                                               new SeaweedType("Alaria"),
                                                               new SeaweedType("Asciphylum"),
                                                               new SeaweedType("Chondrus"),
                                                               new SeaweedType("Fucus"),
                                                               new SeaweedType("Laminaria"));
                    await dbContext.SaveChangesAsync();
                }
            }

            async Task SeedSeaweedCategories()
            {
                var isSeaweedCategoriesEmpty = !await dbContext.SeaweedCategories.AnyAsync();
                if(isSeaweedCategoriesEmpty)
                {
                    await dbContext.SeaweedCategories.AddRangeAsync(new SeaweedCategory("I"),
                                                                    new SeaweedCategory("II"),
                                                                    new SeaweedCategory("III"));
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task Migrate<T>(CancellationToken cancellationToken) where T : DbContext
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            await dbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}