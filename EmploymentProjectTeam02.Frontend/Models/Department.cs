using EmploymentProjectTeam02.Model;

namespace EmploymentProjectTeam02.Frontend.Models;
public class Department
{
    public int Id { get; set; }
    public string? DepartmentName { get; set; }
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}