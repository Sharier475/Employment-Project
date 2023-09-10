using EmploymentProjectTeam02.Shared.Common;

namespace EmploymentProjectTeam02.Model;

public class Country :BaseEntity,IEntity
{
    public String CountryName { get; set; }
    public ICollection<State> states { get; set; } = new HashSet<State>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();


}
