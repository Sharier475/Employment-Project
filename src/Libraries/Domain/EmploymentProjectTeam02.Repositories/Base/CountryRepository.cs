using AutoMapper;
using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Shared.CommonRepository;

namespace EmploymentProjectTeam02.Repositories.Base;

public class CountryRepository : RepositoryBase<Country, VmCountry, int>, ICountryRepository
{
    public CountryRepository(IMapper mapper, DbContext dbContext) : base(mapper, dbContext)
    {
    }
}
