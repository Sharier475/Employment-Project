using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentProjectTeam02.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required,MaxLength(50), DisplayName("Department Name")]
        public  string DepartmentName { get; set; }
      
    }
}
