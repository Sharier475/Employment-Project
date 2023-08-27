using EmploymentProjectTeam02.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentProjectTeam02.Frontend.Models;
public class Department
{
    public int Id { get; set; }
    [DisplayName("Department Name"), Required, MaxLength(50)]
    public string? DepartmentName { get; set; }
}