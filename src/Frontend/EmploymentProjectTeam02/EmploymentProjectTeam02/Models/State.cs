using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmploymentProjectTeam02.Models
{
    public class State
    {
        public int Id { get; set; }
        [Required, MaxLength(25), DisplayName("State Name")]
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
       
    }
}
