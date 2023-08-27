using EmploymentProjectTeam02.Shared.Common;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Services.Model;

public class VmCountry:IVm
{
    public int Id { get; set; }
    [JsonProperty("countryName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public String? CountryName { get; set; }


}
