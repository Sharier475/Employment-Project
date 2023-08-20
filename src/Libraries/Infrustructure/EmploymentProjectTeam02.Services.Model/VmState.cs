using EmploymentProjectTeam02.Shared.Common;

namespace EmploymentProjectTeam02.Services.Model;

public class VmState : IVm
{
    public int Id { get; set ; }
    public string? StateName { get; set; }
    public string? CountryId { get; set; }
    public VmCountry? VmCountry { get; set; }

    public ICollection<VmEmployee> VmEmployees { get; set; } = new HashSet<VmEmployee>();
    public ICollection<VmCity> VmCities { get; set; } = new HashSet<VmCity>();

}
