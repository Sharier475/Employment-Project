using EmploymentProjectTeam02.Infrustructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmploymentProjectTeam02.IoC.Configuration
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddExtention(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmploymentDbContext>(options
           => options.UseSqlServer(configuration.GetConnectionString("MyDbConn")));
            return services;
        }
    }
}
