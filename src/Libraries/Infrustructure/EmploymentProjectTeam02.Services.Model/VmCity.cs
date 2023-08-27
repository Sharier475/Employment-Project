using EmploymentProjectTeam02.Shared.Common;
using System.Text.Json.Serialization;

namespace EmploymentProjectTeam02.Services.Model;

public class VmCity : IVm
{
    public string? CityName { get; set; }
    public int StateId { get; set; }
 
   
    public int Id { get ; set; }
    [JsonIgnore]
    public VmState? State { get; set; }
    [JsonIgnore]
    public ICollection<VmEmployee> VmEmployees { get; set; } = new HashSet<VmEmployee>();
}