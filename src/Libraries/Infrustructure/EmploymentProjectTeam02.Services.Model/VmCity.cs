using EmploymentProjectTeam02.Shared.Common;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace EmploymentProjectTeam02.Services.Model;

public class VmCity : IVm
{
    [JsonProperty("cityName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? CityName { get; set; }
    public int StateId { get; set; }

    public int Id { get ; set; }
   
    public VmState? State { get; set; }
    
    public ICollection<VmEmployee> VmEmployees { get; set; } = new HashSet<VmEmployee>();
}