using ChooseYourAdventure.Core.Common.Interfaces;
using ChooseYourAdventure.Infrastructure.DomainEvents;
using ChooseYourAdventure.Infrastructure.Persistence;
using ChooseYourAdventure.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChooseYourAdventure.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IDomainEventDispatcher>(provider => provider.GetService<DomainEventDispatcher>());

            // DB Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();

            return services;
        }
    }
}
