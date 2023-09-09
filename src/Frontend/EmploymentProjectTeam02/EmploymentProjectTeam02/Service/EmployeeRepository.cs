using EmploymentProjectTeam02.Common;
using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;

namespace EmploymentProjectTeam02.Service;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(IHttpClientFactory httpClientFactory, string endpoint= "Employee") : base(httpClientFactory, endpoint)
    {

    }
}
