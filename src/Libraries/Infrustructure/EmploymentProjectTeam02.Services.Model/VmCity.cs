using EmploymentProjectTeam02.Shared.Common;


namespace EmploymentProjectTeam02.Services.Model;

public class VmCity : IVm
{
    public string? CityName { get; set; }
    public VmState? State { get; set; }
    public int StateId { get; set; }
    public VmState? VmState { get; set; }
    public int Id { get ; set; }
}