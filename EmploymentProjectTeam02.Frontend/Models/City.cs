using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentProjectTeam02.Frontend.Models;

public class City
{
    public int Id { get; set; }
    [DisplayName("City Name"), Required, MaxLength(50)]
    public string? CityName { get; set; }
    public int StateId { get; set; }
    [DisplayName("State Name")]
    public State? StateName { get; set; }
}
