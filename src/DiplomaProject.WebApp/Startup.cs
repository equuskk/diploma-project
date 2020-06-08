using System.Net.Http;
using System.Reflection;
using DiplomaProject.Application.Sectors.Queries;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain;
using DiplomaProject.Domain.Entities;
using DiplomaProject.WebApp.Areas.Identity;
using DiplomaProject.WebApp.HostedServices;
using MatBlazor;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiplomaProject.WebApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString,
                                                                                     x => x.UseNetTopologySuite()));

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

            services.AddRazorPages();

            services.AddServerSideBlazor();

            services.AddScoped<HttpClient>();

            services.AddHostedService<SeedDatabaseHostedService>();
            services.AddHostedService<InitDefaultRolesHostedService>();

            services.AddMediatR(typeof(GetAllSectorsQuery).GetTypeInfo().Assembly);
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomCenter;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = false;
                config.ShowProgressBar = false;
                config.MaximumOpacity = 100;
                config.VisibleStateDuration = 4000;
            });

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}