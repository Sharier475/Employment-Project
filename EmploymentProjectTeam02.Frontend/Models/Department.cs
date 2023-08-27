using EmploymentProjectTeam02.Model;

namespace EmploymentProjectTeam02.Frontend.Models;
public class Department
{
    public int id { get; set; }
    public string? departmentName { get; set; }
    public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();
}