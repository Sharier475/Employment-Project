using AutoMapper;
using EmploymentProjectTeam02.Model;
using EmploymentProjectTeam02.Services.Model;
using System;




namespace EmploymentProjectTeam02.Core.Mapper;

public class CommonMapper : Profile
{
    public CommonMapper()
    {
        CreateMap<VmDepartment, Model.Department>().ReverseMap();
      
        CreateMap<VmCountry, Model.Country>().ReverseMap();
        CreateMap<VmState, Model.State>().ReverseMap();
        CreateMap<VmCity, Model.City>().ReverseMap();
        CreateMap<VmEmployee, Model.Employee>().ReverseMap();


    }
}
