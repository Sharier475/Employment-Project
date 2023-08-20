using AutoMapper;

namespace EmploymentProjectTeam02.Core.Mapper;

public class CommonMapper:Profile
{
    public CommonMapper()
    {
        CreateMap<Services.Model.VmCountry, Model.Country>().ReverseMap();
    }
}
