using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmploymentProjectTeam02.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required, MaxLength(25), DisplayName("Country Name")]
        public String CountryName { get; set; }
       

    }
}
