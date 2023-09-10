using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentProjectTeam02.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required, MaxLength(50), DisplayName("City Name")]
        public string CityName { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
       
    }
}
