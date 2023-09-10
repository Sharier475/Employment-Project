using EmploymentProjectTeam02.Shared.Common;

namespace EmploymentProjectTeam02.Model;

public class Department: BaseEntity,IEntity
{
    public string DepartmentName { get; set; }
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
