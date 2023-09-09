using EmploymentProjectTeam02.Common.Base;
using EmploymentProjectTeam02.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmploymentProjectTeam02.Service.Interface;

public interface IDepartmentRepository:IRepository<Department>
{
    Task<IEnumerable<SelectListItem>> Dropdown();
}
