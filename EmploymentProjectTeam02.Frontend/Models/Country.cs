using System.ComponentModel;

namespace EmploymentProjectTeam02.Frontend.Models;

public class Country
{
    public int Id { get; set; }
    [DisplayName("Country Name")]
    public String? CountryName { get; set; }
    public ICollection<State> States { get; set; } = new HashSet<State>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}