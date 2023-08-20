using AutoMapper;
using EmploymentProjectTeam02.Services.Model;

namespace EmploymentProjectTeam02.Core.Mapper
{
    public class CommonMapper: Profile
    {
        public CommonMapper() 
        {
            CreateMap<Services.Model.VmState,Model.State>().ReverseMap();
            
        }
    }
}
