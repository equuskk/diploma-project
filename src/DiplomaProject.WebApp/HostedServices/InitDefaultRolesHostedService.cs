using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiplomaProject.WebApp.HostedServices
{
    public class InitDefaultRolesHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public InitDefaultRolesHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var manager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var isAdminRoleExists = await manager.RoleExistsAsync(RoleNames.Administrator);
            var isJuniorRoleExists = await manager.RoleExistsAsync(RoleNames.JuniorEmployee);
            var isSeniorRoleExists = await manager.RoleExistsAsync(RoleNames.SeniorEmployee);

            if(!isAdminRoleExists)
            {
                await manager.CreateAsync(new IdentityRole(RoleNames.Administrator));
            }

            if(!isJuniorRoleExists)
            {
                await manager.CreateAsync(new IdentityRole(RoleNames.JuniorEmployee));
            }

            if(!isSeniorRoleExists)
            {
                await manager.CreateAsync(new IdentityRole(RoleNames.SeniorEmployee));
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}