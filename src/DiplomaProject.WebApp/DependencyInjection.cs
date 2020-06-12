using DiplomaProject.DataAccess;
using DiplomaProject.Domain;
using DiplomaProject.Domain.Entities;
using DiplomaProject.WebApp.Areas.Identity;
using DiplomaProject.WebApp.HostedServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomaProject.WebApp
{
    public static class DependencyInjection
    {
        public static void AddAuthStuff(this IServiceCollection services)
        {
            services.AddIdentity<Employee, IdentityRole>(options =>
                    {
#if DEBUG
                        options.User.RequireUniqueEmail = true;
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 6;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredUniqueChars = 0;
#endif
                    })
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<Employee>>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(RoleNames.JuniorEmployee),
                                  policy => policy.RequireRole(RoleNames.JuniorEmployee, RoleNames.SeniorEmployee));
                options.AddPolicy(nameof(RoleNames.SeniorEmployee),
                                  policy => policy.RequireRole(RoleNames.SeniorEmployee));
                options.AddPolicy(nameof(RoleNames.Administrator),
                                  policy => policy.RequireRole(RoleNames.Administrator));
            });
        }

        public static void AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<SeedDatabaseHostedService>();
            services.AddHostedService<InitDefaultRolesHostedService>();
        }
    }
}