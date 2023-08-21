﻿using AutoMapper;
using EmploymentProjectTeam02.Infrustructure;
using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using Microsoft.EntityFrameworkCore;
using Taskmanagement.Shared.CommonRepository;

namespace EmploymentProjectTeam02.Repositories.Base;

public class CountryRepository : RepositoryBase<Country, VmCountry, int>, ICountryRepository
{
    public CountryRepository(IMapper mapper, EmploymentDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
