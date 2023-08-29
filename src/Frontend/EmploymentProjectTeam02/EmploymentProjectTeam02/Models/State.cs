using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentProjectTeam02.Models
{
    public class State
    {
        public int Id { get; set; }
        [DisplayName("Country Name"),Required,MaxLength (50)]
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
      
    }
}
