using AutoMapper;
using EmploymentProjectTeam02.Infrustructure;
using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Shared.CommonRepository;

namespace EmploymentProjectTeam02.Repositories.Base
{
    public class DepartmentRepository:RepositoryBase<Department, VmDepartment, int>,IDepartmentRepositpry
    {
        public DepartmentRepository(IMapper mapper,EmploymentDbContext dbContext) : base(mapper,dbContext) { }
    }
}
