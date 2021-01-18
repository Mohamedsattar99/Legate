using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LegateDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b=>b.MigrationsAssembly("Persistence")));
            services.AddScoped<ILegateDbContext>(provider => provider.GetService<LegateDbContext>());
            return services;
        }
    }
}
