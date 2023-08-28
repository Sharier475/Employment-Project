using EmploymentProjectTeam02.Shared.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentProjectTeam02.Model;

public class Employee : BaseEntity,IEntity
{
  
    public string Name { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public DateTime Joiningdate { get; set; }
    public Boolean SSc { get; set; }
    public Boolean HSc { get; set; }
    public Boolean BSc { get; set; }
    public Boolean MSc { get; set; }
    public string Picture { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public int StateId { get; set; }
    public State State { get; set; }
    public int CityId { get; set; }
    public City City { get; set; } 
}
