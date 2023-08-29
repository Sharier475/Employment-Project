using EmploymentProjectTeam02.Shared.Common;
using System.Text.Json.Serialization;

namespace EmploymentProjectTeam02.Services.Model;

public class VmState : IVm
{
    public int Id { get; set ; }
    public string StateName { get; set; }
    public int CountryId { get; set; }
    public VmCountry Country { get; set; }
        


}
