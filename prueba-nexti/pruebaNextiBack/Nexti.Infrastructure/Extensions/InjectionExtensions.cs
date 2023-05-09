using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexti.Infrastructure.Persistences.Contexts;
using Nexti.Infrastructure.Persistences.Interfaces;
using Nexti.Infrastructure.Persistences.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            var assembly = typeof(pruebaNextiContext).Assembly.FullName;

            service.AddDbContext<pruebaNextiContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("pruebaNextiConection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                    );

            service.AddTransient<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
