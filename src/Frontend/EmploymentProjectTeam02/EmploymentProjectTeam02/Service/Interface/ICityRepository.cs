using EmploymentProjectTeam02.Common.Base;
using EmploymentProjectTeam02.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmploymentProjectTeam02.Service.Interface;

public interface ICityRepository:IRepository<City>
{
    Task<IEnumerable<SelectListItem>> Dropdown();
}
