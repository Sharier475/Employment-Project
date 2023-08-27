namespace EmploymentProjectTeam02.Frontend.Models;
public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Gender { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public DateTime Joiningdate { get; set; }
    public Boolean SSC { get; set; }
    public Boolean HSC { get; set; }
    public Boolean BSC { get; set; }
    public Boolean MSC { get; set; }
    public string? Picture { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public int StateId { get; set; }
    public State? State { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
}

