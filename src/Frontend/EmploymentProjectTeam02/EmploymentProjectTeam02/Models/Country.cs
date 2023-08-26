using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentProjectTeam02.Models
{
    public class Country
    {
        public int id { get; set; }
        [DisplayName("Country Name")]
        public String? countryName { get; set; }
        public ICollection<State> states { get; set; } = new HashSet<State>();
        public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();

    }
}
