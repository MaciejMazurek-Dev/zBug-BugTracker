using BugTracker.Application.Contracts.Persistence;
using BugTracker.Persistence.DatabaseContext;
using BugTracker.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<BTDatabaseContext>(options =>
                //options.UseSqlServer(configuration.GetConnectionString("BTDatabaseConnection")));
                options.UseNpgsql(configuration.GetConnectionString("BTPostgres")));
                

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IIssuePriorityRepository, IssuePriorityRepository>();
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IIssueStatusRepository, IssueStatusRepository>();
            services.AddScoped<IIssueTypeRepository, IssueTypeRepository>();
            
            return services;
        }
    }
}
