using EmploymentProjectTeam02.Core.Mapper;
using EmploymentProjectTeam02.Infrustructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Taskmanagement.Core;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Repositories.Base;

namespace EmploymentProjectTeam02.IoC.Configuration
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddExtention(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmploymentDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("MyDbConn")));
            services.AddTransient<ICountryRepository,CountryRepository>();
            services.AddAutoMapper(typeof(CommonMapper).Assembly);
            services.AddTransient<IDepartmentRepositpry,DepartmentRepository>();
            
            services.AddMediatR(options =>
             options.RegisterServicesFromAssemblies(typeof(ICore).Assembly));
            return services;
        }
    }
}
  