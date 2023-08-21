using AutoMapper;
using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentProjectTeam02.Core.Mapper
{
    public class CommonMapper : Profile
    {
        public CommonMapper()
        {
            CreateMap<VmDepartment, Model.Department>().ReverseMap();
           
        }
    }
}
