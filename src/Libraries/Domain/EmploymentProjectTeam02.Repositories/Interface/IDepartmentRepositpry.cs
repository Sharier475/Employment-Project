using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Shared.CommonRepository;

namespace EmploymentProjectTeam02.Repositories.Interface
{
    public interface IDepartmentRepositpry:IRepository<Department, VmDepartment, int>
    {
    }
}
