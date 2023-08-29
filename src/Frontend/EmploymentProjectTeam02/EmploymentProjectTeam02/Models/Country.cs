using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentProjectTeam02.Models
{
    public class Country
    {
        public int Id { get; set; }
        [DisplayName("Country Name"),Required, MaxLength(50)]
        public String CountryName { get; set; }
       

    }
}
