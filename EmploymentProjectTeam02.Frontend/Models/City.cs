namespace EmploymentProjectTeam02.Frontend.Models;

public class City
{
    public int id { get; set; }
    public string? cityName { get; set; }
    public int stateId { get; set; }
    public State? state { get; set; }
    public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();
}
