using EmploymentProjectTeam02.Shared.Common;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Services.Model;

public class VmState : IVm
{
    public int Id { get; set ; }
    [JsonProperty("stateName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? StateName { get; set; }
    public int CountryId { get; set; }
    public VmCountry? Country { get; set; }
}
