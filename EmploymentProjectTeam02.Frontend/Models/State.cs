using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentProjectTeam02.Frontend.Models;
public class State
{
    public int Id { get; set; }
    [DisplayName("State Name"), Required, MaxLength(50)]
    public string? StateName { get; set; }
    public int CountryId { get; set; }
    [DisplayName("Country Name"), Required, MaxLength(50)]
    public Country? CountryName { get; set; }
   
}
