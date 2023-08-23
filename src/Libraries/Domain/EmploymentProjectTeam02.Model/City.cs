using EmploymentProjectTeam02.Shared.Common;
using System.Collections.Generic;

namespace EmploymentProjectTeam02.Model;

public class City : BaseEntity,IEntity
{
    public string CityName { get; set; }
    public int StateId { get; set; }
    public State State { get; set; }
    public ICollection<Employee> Employees { get; set;} = new HashSet<Employee>();  
}
