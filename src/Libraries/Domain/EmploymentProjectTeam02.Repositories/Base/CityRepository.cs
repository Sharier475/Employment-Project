using AutoMapper;
using EmploymentProjectTeam02.Infrustructure;
using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using Taskmanagement.Shared.CommonRepository;

namespace EmploymentProjectTeam02.Repositories.Base;

public class CityRepository : RepositoryBase<City, VmCity, int>, ICityRepository
{
    public CityRepository(IMapper mapper, EmploymentDbContext dbContext) : base(mapper, dbContext) { }
}
