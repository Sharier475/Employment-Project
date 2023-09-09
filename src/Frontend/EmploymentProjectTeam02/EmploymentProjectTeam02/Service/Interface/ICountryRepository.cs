using EmploymentProjectTeam02.Common.Base;
using EmploymentProjectTeam02.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmploymentProjectTeam02.Service.Interface;

public interface ICountryRepository: IRepository<Country>
{
     Task<IEnumerable<SelectListItem>> Dropdown();
}
