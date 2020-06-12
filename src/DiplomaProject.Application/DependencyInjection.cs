using System.Reflection;
using DiplomaProject.Application.Sectors.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomaProject.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllSectorsQuery).GetTypeInfo().Assembly);
        }
    }
}