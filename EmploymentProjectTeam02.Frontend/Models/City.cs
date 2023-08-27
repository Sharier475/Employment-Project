namespace EmploymentProjectTeam02.Frontend.Models;

public class City
{
    public int Id { get; set; }
    public string? CityName { get; set; }
    public int StateId { get; set; }
    public State? State { get; set; }
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
