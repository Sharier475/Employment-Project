using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmploymentProjectTeam02.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required, MaxLength(25), DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
