using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentProjectTeam02.Frontend.Models;
public class Employee
{
    public int Id { get; set; }
    [DisplayName("Employee Name"), Required, MaxLength(50)]
    public string? EmployeeName { get; set; }
    public string? Address { get; set; }
    public string? Gender { get; set; }
    public int DepartmentId { get; set; }
    [DisplayName("Department Name"), Required, MaxLength(50)]
    public Department? DepartmentName { get; set; }
    public DateTime Joiningdate { get; set; }
    public Boolean SSC { get; set; }
    public Boolean HSC { get; set; }
    public Boolean BSC { get; set; }
    public Boolean MSC { get; set; }
    public string? Picture { get; set; }
    public int CountryId { get; set; }
    [DisplayName("Country Name"), Required, MaxLength(50)]
    public Country? CountryName { get; set; }
    public int StateId { get; set; }
    [DisplayName("State Name")]
    public State? StateName { get; set; }
    public int CityId { get; set; }
    [DisplayName("City Name"), Required, MaxLength(50)]
    public City? CityName { get; set; }
}

