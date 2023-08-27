using EmploymentProjectTeam02.Shared.Common;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Services.Model;

public class VmDepartment:IVm
{
    public int Id { get; set; }
    [JsonProperty("departmentName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? DepartmentName { get; set; }
    
}
