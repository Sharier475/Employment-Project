using AutoMapper;
using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Services.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmploymentProjectTeam02.Core.Mapper;

public class CommonMapper : Profile
{
    public CommonMapper()
    {
        CreateMap<VmCity, Model.City>().ReverseMap();
        CreateMap<VmEmployee, Employee>().ReverseMap();
    }
}
