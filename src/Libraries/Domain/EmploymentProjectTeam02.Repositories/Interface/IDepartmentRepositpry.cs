﻿using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Services.Model;
using Taskmanagement.Shared.CommonRepository;

namespace EmploymentProjectTeam02.Repositories.Interface
{
    public interface IDepartmentRepositpry:IRepository<Department, VmDepartment, int>
    {
    }
}
