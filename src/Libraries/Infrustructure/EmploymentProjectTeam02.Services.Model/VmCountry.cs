using EmploymentProjectTeam02.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentProjectTeam02.Services.Model;

public class VmCountry:IVm
{
    public int Id { get; set; }
    public String? CountryName { get; set; }
     
}
