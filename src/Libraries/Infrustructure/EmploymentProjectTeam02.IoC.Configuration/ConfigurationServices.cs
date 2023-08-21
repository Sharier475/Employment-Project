using EmploymentProjectTeam02.Core.Mapper;
using EmploymentProjectTeam02.Infrustructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Repositories.Base;
using EmploymentProjectTeam02.Core;

namespace EmploymentProjectTeam02.IoC.Configuration
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddExtention(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmploymentDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("MyDbConn")));
            services.AddAutoMapper(typeof(CommonMapper).Assembly);

            //Repository add...
            services.AddTransient<IDepartmentRepositpry, DepartmentRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
                
            });

            return services;
        }
    }
}
  