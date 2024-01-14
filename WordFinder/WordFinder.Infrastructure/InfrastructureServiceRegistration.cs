using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WordFinder.Application.Contracts.Persistence;
using WordFinder.Infrastructure.Persistence;
using WordFinder.Infrastructure.Repositories;

namespace WordFinder.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
              options.UseInMemoryDatabase("InMemoryDatabase"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            return services;
        }
    }
}
