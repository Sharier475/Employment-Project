using EmploymentProjectTeam02.Shared.Common;

namespace EmploymentProjectTeam02.Model;

public class State : BaseEntity,IEntity
{
    public string StateName { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public ICollection<City> cities { get; set; } = new HashSet<City>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
