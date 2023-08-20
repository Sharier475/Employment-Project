using EmploymentProjectTeam02.Shared.Common;

namespace EmploymentProjectTeam02.Services.Model;

public class VmCountry:IVm
{
    public int Id { get; set; }
    public String? CountryName { get; set; }
     public ICollection<VmState> VmStates { get; set; } = new HashSet<VmState>();
     public ICollection<VmEmployee> VmEmployees { get; set; } = new HashSet<VmEmployee>();

}
