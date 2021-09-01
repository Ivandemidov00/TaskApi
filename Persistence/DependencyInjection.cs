
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<ITaskDbContext>(provider =>
                provider.GetService<TaskDbContext>());
            return services;
        }
    }
}