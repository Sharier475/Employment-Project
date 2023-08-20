using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Shared.Common;


namespace EmploymentProjectTeam02.Services.Model
{
    public class VmCity : IVm
    {
        public string? CityName { get; set; }
        public State? State { get; set; }
        public int StateId { get; set; }
        public ICollection<VmEmployee>  vmEmployees { get; set; } = new HashSet<VmEmployee>();
        public int Id { get ; set; }
    }
}