namespace EmploymentProjectTeam02.Models
{
    public class State
    {
        public int id { get; set; }
        public string? stateName { get; set; }
        public int countryId { get; set; }
        public Country? country { get; set; }
        public ICollection<City> cities { get; set; } = new HashSet<City>();
        public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();
    }
}
