namespace EmploymentProjectTeam02.Frontend.Models;
public class State
{
    public int Id { get; set; }
    public string? StateName { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public ICollection<City> Cities { get; set; } = new HashSet<City>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
